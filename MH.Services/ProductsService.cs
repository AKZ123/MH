using MH.Database;
using MH.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        public int GetProductsCount(string search)
        {
            using (var context = new MHDbContext())
            {
                if (!string.IsNullOrEmpty(search))
                {
                    return context.Products.Where(product => product.BrandName != null &&
                         product.BrandName.ToLower().Contains(search.ToLower())).Count();
                }
                else
                {
                    return context.Products.Count();
                }
            }
        }
        #endregion
        public void SaveProduct(Product product)
        {
            //  use   ( Reposetory)
            using (var context = new MHDbContext())
            {
                context.Entry(product.Category).State = System.Data.Entity.EntityState.Unchanged;
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
                return context.Products.Where(x => x.PID == ID).Include(x => x.Category).FirstOrDefault();
                //return context.Products.Find(ID);
            }
        }
       
        public List<Product> GetProducts(string search, int pageNo, int pageSize)
        {
            //int pageSize = 5;
            using (var context = new MHDbContext())
            {
                if (!string.IsNullOrEmpty(search))
                {
                    return context.Products.Where(product => product.BrandName != null &&
                         product.BrandName.ToLower().Contains(search.ToLower()))
                         .OrderBy(x => x.PID)
                         .Skip((pageNo - 1) * pageSize).Take(pageSize)
                         .Include(x => x.Category)
                         .ToList();
                }
                else
                {
                    return context.Products
                        .OrderBy(X => X.PID)
                        .Skip((pageNo - 1) * pageSize)
                        .Take(pageSize)
                        .Include(x => x.Category)
                        .ToList();
                }
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
                //var product = context.Products.Find(ID);
                var product = context.Products.Where(x => x.PID == ID).FirstOrDefault();
                // var category = context.Categories.Where(x => x.CID == ID).Include(x => x.Products).FirstOrDefault();

                //context.Products.RemoveRange(category.Products);  //first delete products of this category
                context.Products.Remove(product);
                context.SaveChanges();
            }
        }

    }
}
