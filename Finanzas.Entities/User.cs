using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finanzas.Entities
{
    public class User:EntityBase
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(30)]
        public string Email { get; set; }

        [StringLength(30)]
        public string Empresa { get; set; }


        [StringLength(30)]
        public string Password { get; set; }

        //Many to Many
        public  ICollection<UserBono> UserBonos { get; set; }

    }
}
