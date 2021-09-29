using MH.Database;
using MH.Entities;
using System;
using System.Collections.Generic;
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

        public List<Category> GetAllCategories()
        {
            using (var context = new MHDbContext())
            {
                return context.Categories.ToList();
            }
        }

        public Category GetCategory(int ID)
        {
            using (var context = new MHDbContext())
            {
                return context.Categories.Find(ID);
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
                var category = context.Categories.Where(x => x.CID == ID).FirstOrDefault();
                // var category = context.Categories.Where(x => x.CID == ID).Include(x => x.Products).FirstOrDefault();

                //context.Products.RemoveRange(category.Products);  //first delete products of this category
                context.Categories.Remove(category);
                context.SaveChanges();
            }
        }

    }
}
