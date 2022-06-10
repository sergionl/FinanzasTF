using Finanzas.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finanzas.DataAccess
{
    public class UserRepository : IUserRepository
    {
        private readonly FinanzasDbContext _context;

        public UserRepository(FinanzasDbContext context)
        {
            _context = context;
        }

        public async Task Create(User entity)
        {
            _context.Set<User>().Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            _context.Entry(new User
            {
                Id = id
            }).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<User> GetItem(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task Update(User entity)
        {
            _context.Set<User>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
