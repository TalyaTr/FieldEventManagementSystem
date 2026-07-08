using System.Collections.Generic;
using System.Numerics;
using DAL.DataObjects;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class FieldEventContext : DbContext
    {
        public DbSet<User> Users{ get; set; }
        public DbSet<Source> Sources { get; set; }
        public DbSet<FieldEvent> FieldEvents { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}
