using MH.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MH.Database
{
    public class MHDbContext : IdentityDbContext<ApplicationUser>  //DbContext
    {
        public MHDbContext() : base("name=MHConnection")
        {

        }
        public static MHDbContext Create()
        {
            return new MHDbContext();
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Batch> Batches { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<ProductState> ProductState { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItem { get; set; }



        public DbSet<Country> Countries { get; set; }
        public DbSet<Division> Divisions { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Upazila> Upazilas { get; set; }
        
    }
}
