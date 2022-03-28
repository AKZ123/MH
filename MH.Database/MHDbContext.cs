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
        public DbSet<Category> Categories { get; set; }//CRUD
        public DbSet<Product> Products { get; set; }//CRUD
        public DbSet<Company> Companies { get; set; }//CRUD
        public DbSet<Batch> Batches { get; set; }
        public DbSet<ProductBatchUser> ProductBatchToUser { get; set; }
        public DbSet<State> States { get; set; }//-
        //public DbSet<ProductState> ProductState { get; set; }//
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItem { get; set; }//Bridge to Batch
        public DbSet<SaleArea> SaleAreas { get; set; }//-
        public DbSet<UserSaleArea> UserSaleArea { get; set; }//
        public DbSet<UAddress> UAddress { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<UserStore> UserStore { get; set; }



        public DbSet<Country> Countries { get; set; }//CRUD
        public DbSet<Division> Divisions { get; set; }//CRUD
        public DbSet<District> Districts { get; set; }//CRUD
        public DbSet<Upazila> Upazilas { get; set; }//CRUD

    }
}
