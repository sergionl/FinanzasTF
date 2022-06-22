using Finanzas.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finanzas.DataAccess
{
    public interface IUserBonoRepository
    {

        Task<UserBono> GetItem(int userId, int bonoId);
        Task<ICollection<UserBono>> GetItemsByUserId(int id);
        Task Create(UserBono entity);

        Task Delete(int userId, int bonoId);
    }
}
