using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SupplementStore.Domain.Entities;
using System.Data.Entity;

namespace SupplementStore.Domain.Concrete
{
   public class EFDbContext : System.Data.Entity.DbContext
    {
        public DbSet<Product> Products { get; set; }
    }
}
