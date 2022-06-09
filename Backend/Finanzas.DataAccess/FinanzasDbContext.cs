using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Finanzas.Entities;
using Microsoft.EntityFrameworkCore;

namespace Finanzas.DataAccess
{
    public class FinanzasDbContext: IdentityDbContext
    {
        public FinanzasDbContext(
            DbContextOptions<FinanzasDbContext> options)
            : base(options)
        {

        }

        public FinanzasDbContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(@"Server = DESKTOP-VH303IU; Database = FinanzasDB; Integrated Security = true;");
        }

        public DbSet<User> Users { get; set; }
        
        public DbSet<Bono> Bonos { get; set; }

        public DbSet<UserBono> UserBonos { get; set; }

    }
}
