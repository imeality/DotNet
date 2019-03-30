using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FirstWebApi.Models
{
    public class HealthPlusContext : DbContext
    {
        static HealthPlusContext()
        {
            Database.SetInitializer<HealthPlusContext>(null);
        }

        public HealthPlusContext()
            : base("Name=HealthPlusContext")
        {
        }

        public DbSet<User> Users { get; set; }
       

    }
}