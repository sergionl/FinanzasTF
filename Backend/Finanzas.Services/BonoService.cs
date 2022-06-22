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
    public class BonoService : IBonoService
    {
        private readonly IBonoRepository _repository;

        public BonoService(IBonoRepository repository)
        {
            _repository = repository;
        }

        public async Task Create(BonoDto entity)
        {
            if (entity.Precio <= 0)
            {
                throw new FinanzasException("Prize should be greater than 0");
            }
            if (entity.TasaAnual <= 0)
            {
                throw new FinanzasException("TA should be greater than 0");
            }
            if (entity.ValorNominal <= 0)
            {
                throw new FinanzasException("Nominal Value should be greater than 0");
            }

            if (string.IsNullOrEmpty(entity.PeriodoDePago))
            {
                throw new FinanzasException("It is neccesary to add a Period");
            }
            if (string.IsNullOrEmpty(entity.nombre))
            {
                throw new FinanzasException("It is neccesary to add a name");
            }


            await _repository.Create(new Bono
            {
                Precio = entity.Precio,
                TasaAnual = entity.TasaAnual,
                ValorNominal = entity.ValorNominal,
                PeriodoDePago = entity.PeriodoDePago,
                nombre = entity.nombre,
                Soles = entity.Soles,
                MercadoPrimario = entity.MercadoPrimario,
            });
        }

        public async Task Delete(int id)
        {
            try
            {
                await _repository.Delete(id);

            }
            catch (Exception e)
            {
                throw new NullReferenceException("Error deleting bono id " + id.ToString());
            }
        }

        public async Task<BonoDto> GetItem(int id)
        {
            Bono bono = await _repository.GetItem(id);
            if (bono == null)
            {
                throw new NullReferenceException("No Bono exist with id " + id.ToString());
            }

            BonoDto bonoDto = new BonoDto();

            bonoDto.Id = bono.Id;
            bonoDto.Precio = bono.Precio;
            bonoDto.TasaAnual = bono.TasaAnual;
            bonoDto.ValorNominal = bono.ValorNominal;
            bonoDto.PeriodoDePago = bono.PeriodoDePago;
            bonoDto.nombre = bono.nombre;
            bonoDto.Soles = bono.Soles;
            bonoDto.MercadoPrimario = bono.MercadoPrimario;



            return bonoDto;
        }

        public async Task Update(BonoDto entity)
        {
            Bono bono = await _repository.GetItem(entity.Id);

            if (bono == null)
            {
                throw new NullReferenceException("No User exist with id " + entity.Id.ToString());
            }

            bono.Id = entity.Id;
            bono.Precio = entity.Precio;
            bono.TasaAnual = entity.TasaAnual;
            bono.ValorNominal = entity.ValorNominal;
            bono.PeriodoDePago = entity.PeriodoDePago;
            bono.nombre = entity.nombre;
            bono.Soles = entity.Soles;
            bono.MercadoPrimario = entity.MercadoPrimario;

            await _repository.Update(bono);
        }
        public async Task<ICollection<BonoDto>> GetCollection(string filter)
        {
            var Collection = await _repository.GetBonos(filter ?? string.Empty);
            return Collection.Select(c => new BonoDto
            {
                Id = c.Id,
                Precio = c.Precio,
                TasaAnual = c.TasaAnual,
                ValorNominal = c.ValorNominal,
                PeriodoDePago = c.PeriodoDePago,
                nombre = c.nombre,
                Soles = c.Soles,
                MercadoPrimario = c.MercadoPrimario
            }).ToList();
        }
    }
}
