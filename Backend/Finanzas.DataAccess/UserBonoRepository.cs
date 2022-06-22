using Finanzas.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finanzas.DataAccess
{
    public class UserBonoRepository : IUserBonoRepository
    {
        private readonly FinanzasDbContext _context;

        public UserBonoRepository(FinanzasDbContext context)
        {
            _context = context;
        }
        public async Task Create(UserBono entity)
        {
            _context.Set<UserBono>().Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int userId, int bonoId)
        {
            _context.Entry(new UserBono
            {
                UserId = userId,
                BonoId = bonoId
            }).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<UserBono>> GetItemsByUserId(int id)
        {
            return await _context.UserBonos.Where(c => c.UserId.Equals(id))
                .ToListAsync();
        }
        public async Task<UserBono> GetItem(int userId, int groupId)
        {
            UserBono userGroup = await _context.UserBonos.
                FindAsync(userId, groupId);
            userGroup.User = await _context.Users.FindAsync(userId);
            userGroup.Bono = await _context.Bonos.FindAsync(groupId);
            return userGroup;
        }
    }
}
