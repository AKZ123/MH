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
    public class UserAllOtherService
    {
        #region Singleton
        public static UserAllOtherService Instance
        {
            get
            {
                if (instance == null) instance = new UserAllOtherService();
                return instance;
            }
        }
        private static UserAllOtherService instance { get; set; }
        private UserAllOtherService()
        {

        }
        #endregion
        public List<UAddress> GetUserAddresses(string userID)
        {
            //int pageSize = 5;
            using (var context = new MHDbContext())
            {
                return context.UAddress.Where(x => x.UserId != null && x.UserId.ToLower().Contains(userID.ToLower()))
                         .OrderBy(x => x.Type).ToList();
            }
        }
        //public int SearchProductsCount(string searchTerm, int? minimumPrice, int? maximumPrice, int? categoryID, int? sortBy)
        //{
        //    using (var context = new MHDbContext())
        //    {
        //        var products = context.Products.ToList();
        //        if (categoryID.HasValue)
        //        {
        //            products = products.Where(x => x.Category.CID == categoryID.Value).ToList();
        //        }
        //        if (!string.IsNullOrEmpty(searchTerm))
        //        {
        //            products = products.Where(x => x.BrandName.ToLower().Contains(searchTerm.ToLower())).ToList();
        //        }
        //        //if (minimumPrice.HasValue)
        //        //{
        //        //    products = products.Where(x => x.Price >= minimumPrice.Value).ToList();
        //        //}
        //        //if (maximumPrice.HasValue)
        //        //{
        //        //    products = products.Where(x => x.Price <= maximumPrice.Value).ToList();
        //        //}
        //        //if (sortBy.HasValue)
        //        //{
        //        //    switch (sortBy.Value)
        //        //    {
        //        //        case 2:
        //        //            products = products.OrderByDescending(x => x.ID).ToList();
        //        //            break;
        //        //        case 3:
        //        //            products = products.OrderBy(x => x.Price).ToList();
        //        //            break;
        //        //        default:
        //        //            products = products.OrderByDescending(x => x.Price).ToList();
        //        //            break;
        //        //    }
        //        //}
        //        return products.Count;
        //    }
        //}
        //public int GetUserAddressCount(string userID)
        //{
        //    using (var context = new MHDbContext())
        //    {
        //        if (!string.IsNullOrEmpty(userID))
        //        {
        //            return context.UAddress.Where(x => x.UserId != null &&
        //                 x.UserId.ToLower().Contains(userID.ToLower())).Count();
        //        }
        //        else
        //        {
        //            return context.UAddress.Count();
        //        }
        //    }
        //}
        //public void SaveUserAddress(UAddress address)
        //{
        //    //  use   ( Reposetory)
        //    using (var context = new MHDbContext())
        //    {
        //        context.Entry(address.ApplicationUser).State = System.Data.Entity.EntityState.Unchanged;
        //        //context.Entry(product.Category).State = System.Data.Entity.EntityState.Unchanged;
        //        context.UAddress.Add(address);
        //        context.SaveChanges();
        //    }
        //}
        //public List<UAddress> GetAllAddress()
        //{
        //    using (var context = new MHDbContext())
        //    {
        //        return context.UAddress.ToList();
        //    }
        //}
        //public UAddress GetAddress(int ID)
        //{
        //    using (var context = new MHDbContext())
        //    {
        //        return context.UAddress.Where(x => x.AddressID == ID).Include(x => x.ApplicationUser).FirstOrDefault();
        //        //return context.Products.Where(x => x.PID == ID).Include(x => x.Category).FirstOrDefault();
        //        //return context.Products.Find(ID);
        //    }
        //}
        //public List<Product> GetProducts(string search, int pageNo, int pageSize)
        //{
        //    //int pageSize = 5;
        //    using (var context = new MHDbContext())
        //    {
        //        if (!string.IsNullOrEmpty(search))
        //        {
        //            return context.Products.Where(product => product.BrandName != null &&
        //                 product.BrandName.ToLower().Contains(search.ToLower()))
        //                 .OrderBy(x => x.PID)
        //                 .Skip((pageNo - 1) * pageSize).Take(pageSize)
        //                 .Include(x => x.Category)
        //                 .Include(x => x.Company)
        //                 .ToList();
        //        }
        //        else
        //        {
        //            return context.Products
        //                .OrderBy(X => X.PID)
        //                .Skip((pageNo - 1) * pageSize)
        //                .Take(pageSize)
        //                .Include(x => x.Category)
        //                .Include(x => x.Company)
        //                .ToList();
        //        }
        //    }
        //}
        //public void UpdateProduct(Product product)
        //{
        //    using (var context = new MHDbContext())
        //    {
        //        context.Entry(product).State = System.Data.Entity.EntityState.Modified;
        //        context.SaveChanges();
        //    }
        //}
        //public void DeleteProduct(int ID)
        //{
        //    using (var context = new MHDbContext())
        //    {
        //        //var product = context.Products.Find(ID);
        //        var product = context.Products.Where(x => x.PID == ID).FirstOrDefault();
        //        // var category = context.Categories.Where(x => x.CID == ID).Include(x => x.Products).FirstOrDefault();

        //        //context.Products.RemoveRange(category.Products);  //first delete products of this category
        //        context.Products.Remove(product);
        //        context.SaveChanges();
        //    }
        //}
        //public List<Product> GetProducts(List<int> IDs)
        //{
        //    using (var context = new MHDbContext())
        //    {
        //        return context.Products.Where(Product => IDs.Contains(Product.PID)).ToList();
        //    }
        //}
    }
}
