using Finanzas.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finanzas.DataAccess
{
    public interface IUserRepository
    {
        Task<User> GetItem(int id);
        Task Create(User entity);
        Task Update(User entity);
        Task Delete(int id);

        Task<User> GetItemByEmail(string email);
    }
}
