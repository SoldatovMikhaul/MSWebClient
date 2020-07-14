using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace WebApplication2.Models
{
    public class ApplicationContext : DbContext
    {
        // public DbSet<User> Users { get; set; }
        /*public DbSet<TV> TVS { get; set; }*/
        public DbSet<WebApplication2.Models.User> t_Users { get; set; }
        public DbSet<WebApplication2.Models.Child> Child { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
                :base(options)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }
    }
}
