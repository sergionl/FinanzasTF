using Finanzas.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finanzas.DataAccess
{
    public interface IBonoRepository
    {
        Task<Bono> GetItem(int id);
        Task Create(Bono entity);
        Task Update(Bono entity);
        Task Delete(int id);

        Task<ICollection<Bono>> GetBonos(string filter);

    }
}
