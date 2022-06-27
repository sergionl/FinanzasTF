using Finanzas.DataAccess;
using Finanzas.Dto;
using Finanzas.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel.FinancialFunctions;


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

            //calcular van
            double van = 0;
            double ta = entity.TasaAnual / 100.0;
            double interes = entity.ValorNominal*ta;
            for(double i = 1; i < entity.Tiempo+1; i++)
            {
                if (i != entity.Tiempo)
                {
                    van += interes / Math.Pow(1+ta,i);
                }
                else
                {
                    double aux = (entity.ValorNominal + interes) / Math.Pow(1 + ta, i);
                    van += aux;
                }
            }
            //int tamanio = entity.Tiempo;

            double[] cashFlows = new double[] { -entity.ValorNominal };
            
            for (double i = 1; i < entity.Tiempo + 1; i++)
            {
                if (i != entity.Tiempo)
                {
                    cashFlows = cashFlows.Concat(new double[] {interes}).ToArray();
                    //cashFlows.Append(interes);
                }
                else
                {
                    cashFlows = cashFlows.Concat(new double[] { entity.ValorNominal + interes }).ToArray();
                    //cashFlows.Append(entity.ValorNominal+interes);
                }
            }
            double irr = Financial.Irr(cashFlows);

            double convex = 0;

            throw new FinanzasException("It is neccesary to add a name");


            await _repository.Create(new Bono
            {
                Precio = entity.Precio,
                TasaAnual = entity.TasaAnual,
                ValorNominal = entity.ValorNominal,
                PeriodoDePago = entity.PeriodoDePago,
                Tiempo = entity.Tiempo,
                nombre = entity.nombre,
                Soles = entity.Soles,
                MercadoPrimario = entity.MercadoPrimario,
                VAN = van,
                TIR = irr,
                Convex = convex,
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
            bonoDto.Tiempo = bono.Tiempo;
            bonoDto.nombre = bono.nombre;
            bonoDto.Soles = bono.Soles;
            bonoDto.MercadoPrimario = bono.MercadoPrimario;
            bonoDto.VAN = bono.VAN;
            bonoDto.TIR = bono.TIR;
            bonoDto.Convex = bono.Convex;



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
            bono.Tiempo = entity.Tiempo;
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
                Tiempo = c.Tiempo,
                nombre = c.nombre,
                Soles = c.Soles,
                MercadoPrimario = c.MercadoPrimario,
                VAN = c.VAN,
                TIR = c.TIR,
                Convex = c.Convex
            }).ToList();
        }
    }
}
