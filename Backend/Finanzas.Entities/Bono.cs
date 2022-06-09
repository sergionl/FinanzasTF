using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finanzas.Entities
{
    public class Bono:EntityBase
    {
     
        public int TasaAnual { get; set; }
  
        public int Vencimiento { get; set; }

        public int TiempoFaltante { get; set; }

        public int MaxGrade { get; set; }

        //Many to Many
        public ICollection<UserBono> UserBonos { get; set; }
    }
}
