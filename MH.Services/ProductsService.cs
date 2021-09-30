using MH.Database;
using MH.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MH.Services
{
    public class ProductsService
    {
        #region Singleton
        public static ProductsService Instance
        {
            get
            {
                if (instance == null) instance = new ProductsService();
                return instance;
            }
        }
        private static ProductsService instance { get; set; }
        private ProductsService()
        {

        }
        #endregion
        public void SaveProduct(Product product)
        {
            using (var context = new MHDbContext())
            {
                context.Products.Add(product);
                context.SaveChanges();
            }
        }

        public List<Product> GetAllProducts()
        {
            using (var context = new MHDbContext())
            {
                return context.Products.ToList();
            }
        }

        public Product GetProduct(int ID)
        {
            using (var context = new MHDbContext())
            {
                return context.Products.Find(ID);
            }
        }

        public void UpdateProduct(Product product)
        {
            using (var context = new MHDbContext())
            {
                context.Entry(product).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void DeleteProduct(int ID)
        {
            using (var context = new MHDbContext())
            {
                var product = context.Products.Where(x => x.PID == ID).FirstOrDefault();
                // var category = context.Categories.Where(x => x.CID == ID).Include(x => x.Products).FirstOrDefault();

                //context.Products.RemoveRange(category.Products);  //first delete products of this category
                context.Products.Remove(product);
                context.SaveChanges();
            }
        }

    }
}
