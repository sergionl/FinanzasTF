using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finanzas.Entities
{
    public class Bono:EntityBase
    {

        public int Precio { get; set; }
        public int TasaAnual { get; set; }
  
        public int ValorNominal { get; set; }

        public int Tiempo { get; set; }

        public string PeriodoDePago { get; set; }

        public string nombre { get; set; }

        public bool Soles { get; set; }

        public bool MercadoPrimario { get; set; }

        public double VAN { get; set; }

        public double TIR { get; set; }

        public double Convex { get; set; }

        //Many to Many
        public ICollection<UserBono> UserBonos { get; set; }
    }
}
