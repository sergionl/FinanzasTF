using Finanzas.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finanzas.Services
{
    public interface IBonoService
    {
        Task<BonoDto> GetItem(int id);
        Task Create(BonoDto entity);
        Task Update(BonoDto entity);
        Task Delete(int id);

        Task<ICollection<BonoDto>> GetCollection(string filter);

    }
}
