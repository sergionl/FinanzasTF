using Finanzas.Dto;
using Finanzas.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finanzas.Services
{
    public interface IUserService
    {
        Task<UserDto> GetItem(int id);
        Task Create(UserDto entity);
        Task Update(UserDto entity);
        Task Delete(int id);
    }
}
