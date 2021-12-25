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
    public class CategoriesService
    {
        #region Singleton
        public static CategoriesService Instance
        {
            get
            {
                if (instance == null) instance = new CategoriesService();
                return instance;
            }
        }
        private static CategoriesService instance { get; set; }
        private CategoriesService()
        {

        }
        #endregion
        public void SaveCategory(Category category)
        {
            using (var context = new MHDbContext())
            {
                context.Categories.Add(category);
                context.SaveChanges();
            }
        }
        public Category GetCategory(int ID)
        {
            using (var context = new MHDbContext())
            {
                return context.Categories.Find(ID);
            }
        }
  
        public int GetCategoriesCount(string search)
        {
            using (var context = new MHDbContext())
            {
                if (!string.IsNullOrEmpty(search))
                {
                    return context.Categories.Where(category => category.Name != null &&
                         category.Name.ToLower().Contains(search.ToLower())).Count();
                }
                else
                {
                    return context.Categories.Count();
                }
            }
        }
        public List<Category> GetAllCategories()
        {
            using (var context = new MHDbContext())
            {
                return context.Categories.ToList();
            }
        }
        public List<Category> GetCategories(string search, int pageNo)
        {
            int pageSize = 10;

            using (var context = new MHDbContext())
            {
                if (!string.IsNullOrEmpty(search))
                {
                    return context.Categories.Where(category => category.Name != null &&
                         category.Name.ToLower().Contains(search.ToLower()))
                         .OrderBy(x => x.CID)
                         .Skip((pageNo - 1) * pageSize)
                         .Take(pageSize)
                         .Include(x => x.Products)
                         .ToList();
                }
                else
                {
                    return context.Categories
                        .OrderBy(x => x.CID)
                        .Skip((pageNo - 1) * pageSize)
                        .Take(pageSize)
                        .Include(x => x.Products)
                        .ToList();
                }
            }
        }

        public void UpdateCategory(Category category)
        {
            using (var context = new MHDbContext())
            {
                context.Entry(category).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void DeleteCategory(int ID)
        {
            using (var context = new MHDbContext())
            {
                //var category = context.Categories.Where(x => x.CID == ID).FirstOrDefault();
                 var category = context.Categories.Where(x => x.CID == ID).Include(x => x.Products).FirstOrDefault();

                context.Products.RemoveRange(category.Products);  //first delete products of this category
                context.Categories.Remove(category);
                context.SaveChanges();
            }
        }

    }
}
