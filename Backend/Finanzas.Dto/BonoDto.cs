using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finanzas.Dto
{
    public class BonoDto
    {
        public int Id { get; set; }

        public int TasaAnual { get; set; }

        public int Vencimiento { get; set; }

        public int TiempoFaltante { get; set; }

        public int MaxGrade { get; set; }
    }
}
