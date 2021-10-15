using s3_proj.Models;
using System.Data.Entity.ModelConfiguration.Conventions;
using Microsoft.EntityFrameworkCore;

namespace s3_proj.Data
{
    public class DataContext : DbContext
    {

        
            public DataContext(DbContextOptions<DataContext> options) : base(options) {

            }
        

        public DbSet<Weapon> Weapons { get; set; }

       
    }
}