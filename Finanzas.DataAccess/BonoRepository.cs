using Finanzas.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finanzas.DataAccess
{
    public class BonoRepository : IBonoRepository
    {
        private readonly FinanzasDbContext _context;

        public BonoRepository(FinanzasDbContext context)
        {
            _context = context;
        }

        public async Task Create(Bono entity)
        {
            _context.Set<Bono>().Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            _context.Entry(new Bono
            {
                Id = id
            }).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<Bono> GetItem(int id)
        {
            return await _context.Bonos.FindAsync(id);
        }

        public async Task Update(Bono entity)
        {
            _context.Set<Bono>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task<ICollection<Bono>> GetBonos(string filter)
        {
            return await _context.Bonos.Where(c => c.nombre.Contains(filter))
                   .ToListAsync();
        }
    }
}
