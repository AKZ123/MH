using MH.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MH.Services
{
    public class DashboardService
    {
        #region Singleton
        public static DashboardService Instance
        {
            get
            {
                if (instance == null) instance = new DashboardService();
                return instance;
            }
        }
        private static DashboardService instance { get; set; }
        private DashboardService()
        {
        }
        //////////
        #endregion

        public int GetUserCount()
        {
            using (var context = new MHDbContext())
            {
                return context.Users.Count();
            }
        }
        MHDbContext context = new MHDbContext();

        public int GetProductCount()
        {
            using (var context = new MHDbContext())
            {
                return context.Products.Count();
            }
        }

        public int GetRoleCount()
        {
            using (var context = new MHDbContext())
            {
                return context.Roles.Count();
            }
        }

        //public List<Comment> GetCommentsByUser(string userId, int entityID)
        //{
        //    return context.Comments.Where(x => x.UserID == userId).Where(x => x.EntityID == entityID).OrderByDescending(x => x.TimeStamp).ToList();
        //}
    }
}
