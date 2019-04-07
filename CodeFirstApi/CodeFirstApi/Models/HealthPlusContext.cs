using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CodeFirstApi.Models
{
    public class HealthPlusContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Membership> Memberships { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<LiveDoc> LiveDocs { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
    }
}