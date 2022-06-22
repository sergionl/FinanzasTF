using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finanzas.Entities
{
    public class UserBono:EntityBase
    {
        public int UserId { get; set; }
        public User User { get; set; }

        public int BonoId { get; set; }
        public Bono Bono { get; set; }
    }
}
