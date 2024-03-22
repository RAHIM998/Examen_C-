using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_De_Facturation.Models
{
    class MyDbContext:DbContext
    {
        public MyDbContext():base("DefaultConnection")
        {

        }

        public DbSet<Clients> Clients { get; set; }
        public DbSet<Comptes> Comptes { get; set; }
        public DbSet<Factures> Factures { get; set; }
        public DbSet<Paiements> Paiements { get; set; }
    }
}
