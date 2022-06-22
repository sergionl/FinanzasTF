using Finanzas.DataAccess;
using Finanzas.Dto;
using Finanzas.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finanzas.Services
{
    public class UserBonoService : IUserBonoService
    {
        private readonly IUserBonoRepository _repository;

        public UserBonoService(IUserBonoRepository repository)
        {
            _repository = repository;
        }

        public async Task Create(UserBonoDto entity)
        {
            try
            {
                //A
                await _repository.Create(new UserBono
                {
                    UserId = entity.UserId,
                    BonoId = entity.BonoId,
                });
            }
            catch (Exception)
            {
                throw new FinanzasException("Error buying");
            }
        }

        public async Task DeleteUsingUser(int userId, int bonoId)
        {
            _repository.Delete(userId, bonoId);
        }

        public async Task<ICollection<UserBonoDto>> GetItemsByUserId(int id)
        {
            var Collection = await _repository.GetItemsByUserId(id);

            return Collection.Select(c => new UserBonoDto
            {
                UserId = c.UserId,
                BonoId = c.BonoId,

            }).ToList();
        }
    }
}
