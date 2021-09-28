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


    }
}
