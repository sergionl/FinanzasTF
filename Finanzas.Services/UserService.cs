using Finanzas.DataAccess;
using Finanzas.Dto;
using Finanzas.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Finanzas.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task Create(UserDto entity)
        {
            
            if (entity.Name == "" || entity.Name == null)
            {
                throw new FinanzasException("It is neccesary to add a name");
            }

            if (string.IsNullOrEmpty(entity.Email))
            {
                throw new FinanzasException("It is neccesary to add email");
            }
            if (string.IsNullOrEmpty(entity.Password))
            {
                throw new FinanzasException("It is neccesary to add a password");
            }
            try
            {
                var correo = new MailAddress(entity.Email);
                entity.Email = correo.Address;
            }
            catch
            {
                throw new FinanzasException("Email invalid");
            }


            await _repository.Create(new User
            {
                Name = entity.Name,
                Email = entity.Email,
                Password = entity.Password,
                Empresa = entity.Empresa,
            });

            //return entity;
        }

        public async Task Delete(int id)
        {
            try
            {
                await _repository.Delete(id);

            }
            catch (Exception e)
            {
                throw new NullReferenceException("Error deleting user id " + id.ToString());
            }
        }

        public async Task<UserDto> GetItem(int id)
        {
            User user = await _repository.GetItem(id);
            if (user == null)
            {
                throw new NullReferenceException("No User exist with id " + id.ToString());
            }

            UserDto userDto = new UserDto();

            userDto.Id = user.Id;
            userDto.Name = user.Name;
            userDto.Email = user.Email;
            userDto.Empresa = user.Empresa;
            

            return userDto;
        }

        public async Task Update(UserDto entity)
        {
            User user = await _repository.GetItem(entity.Id);

            if (user == null)
            {
                throw new NullReferenceException("No User exist with id " + entity.Id.ToString());
            }

            user.Name = entity.Name;
            user.Email = entity.Email;
            user.Empresa = entity.Empresa;

            await _repository.Update(user);
        }
    }
}
