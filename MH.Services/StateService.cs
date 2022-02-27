using MH.Database;
using MH.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MH.Services
{
    public class StateService
    {
        #region Singleton
        public static StateService Instance
        {
            get
            {
                if (instance == null) instance = new StateService();
                return instance;
            }
        }
        private static StateService instance { get; set; }
        private StateService()
        {
        }
        #endregion
        //3
        public int GetStatesCount(string search)
        {
            using (var context = new MHDbContext())
            {
                if (!string.IsNullOrEmpty(search))
                {
                    return context.States.Where(state => state.StateName != null &&
                         state.StateName.ToLower().Contains(search.ToLower())).Count();
                }
                else
                {
                    return context.States.Count();
                }
            }
        }
        //1
        public void SaveState(State state)
        {
            using (var context = new MHDbContext())
            {
                context.States.Add(state);
                context.SaveChanges();
            }
        }
        //2
        public State GetState(int ID)
        {
            using (var context = new MHDbContext())
            {
                return context.States.Where(x => x.SID == ID).FirstOrDefault();
            }
        }
        //5
        public List<State> GetStates(string search, int pageNo, int pageSize)
        {
            //int pageSize = 5;
            using (var context = new MHDbContext())
            {
                if (!string.IsNullOrEmpty(search))
                {
                    return context.States.Where(state => state.StateName != null &&
                         state.StateName.ToLower().Contains(search.ToLower()))
                         .OrderBy(x => x.SID)
                         .Skip((pageNo - 1) * pageSize).Take(pageSize)
                         .ToList();
                }
                else
                {
                    return context.States
                        .OrderBy(X => X.SID)
                        .Skip((pageNo - 1) * pageSize)
                        .Take(pageSize)
                        .ToList();
                }
            }
        }
        //6
        public void UpdateState(State state)
        {
            using (var context = new MHDbContext())
            {
                context.Entry(state).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }
        //7
        public void DeleteState(int ID)
        {
            using (var context = new MHDbContext())
            {
                //var product = context.Products.Find(ID);
                var state = context.States.Where(x => x.SID == ID).FirstOrDefault();
                // var category = context.Categories.Where(x => x.CID == ID).Include(x => x.Products).FirstOrDefault();

                //context.Products.RemoveRange(category.Products);  //first delete products of this category
                context.States.Remove(state);
                context.SaveChanges();
            }
        }
       
    }
}
