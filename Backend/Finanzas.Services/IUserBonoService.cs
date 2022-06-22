using Finanzas.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finanzas.Services
{
    public interface IUserBonoService
    {
        Task<ICollection<UserBonoDto>> GetItemsByUserId(int id);
        Task Create(UserBonoDto entity);
        Task DeleteUsingUser(int userId, int bonoId);
    }
}
