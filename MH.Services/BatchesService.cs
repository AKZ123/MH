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
    public class BatchesService
    {
        #region Singleton
        public static BatchesService Instance
        {
            get
            {
                if (instance == null) instance = new BatchesService();
                return instance;
            }
        }
        private static BatchesService instance { get; set; }
        private BatchesService()
        {

        }
        #endregion

        public int SearchBatchesCount(string searchTerm, int? PID /*, int? minimumPrice, int? maximumPrice, int? sortBy*/)
        {
            using (var context = new MHDbContext())
            {
                var batches = context.Batches.ToList();
                if (!string.IsNullOrEmpty(searchTerm))
                {
                    batches = batches.Where(x => x.BatchNo.ToLower().Contains(searchTerm.ToLower())).ToList();
                }
                if (PID.HasValue)
                {
                    batches = batches.Where(x => x.ProductId == PID.Value).ToList();
                }
                //if (maximumPrice.HasValue)
                //{
                //    products = products.Where(x => x.Price <= maximumPrice.Value).ToList();
                //}
                //if (sortBy.HasValue)
                //{
                //    switch (sortBy.Value)
                //    {
                //        case 2:
                //            products = products.OrderByDescending(x => x.ID).ToList();
                //            break;
                //        case 3:
                //            products = products.OrderBy(x => x.Price).ToList();
                //            break;
                //        default:
                //            products = products.OrderByDescending(x => x.Price).ToList();
                //            break;
                //    }
                //}
                return batches.Count;
            }
        }
        public int GetBatchesCount(string search)
        {
            using (var context = new MHDbContext())
            {
                if (!string.IsNullOrEmpty(search))
                {
                    return context.Batches.Where(x => x.BatchNo != null &&
                         x.BatchNo.ToLower().Contains(search.ToLower())).Count();
                }
                else
                {
                    return context.Batches.Count();
                }
            }
        }
        public void SaveBatch(Batch batch)
        {
            //  use   ( Reposetory)
            using (var context = new MHDbContext())
            {
                context.Entry(batch.Product).State = System.Data.Entity.EntityState.Unchanged;                
                context.Batches.Add(batch);
                context.SaveChanges();
            }
        }
        public List<Batch> GetAllBatches()
        {
            using (var context = new MHDbContext())
            {
                return context.Batches.ToList();
            }
        }
        public Batch GetBatch(int ID)
        {
            using (var context = new MHDbContext())
            {
                return context.Batches.Where(x => x.BID == ID).Include(x => x.Product).Include(x=>x.ProductBatchUsers).FirstOrDefault();
                //return context.Products.Where(x => x.PID == ID).Include(x => x.Category).FirstOrDefault();
                //return context.Products.Find(ID);
            }
        }
        public List<Batch> GetBatches(string search,int? PID, int pageNo, int pageSize)
        {
            //int pageSize = 5;
            using (var context = new MHDbContext())
            {
                var batches = context.Batches.Include(x => x.Product).Include(x => x.ProductBatchUsers).ToList();
                if (!string.IsNullOrEmpty(search))
                {
                    batches = batches.Where(x => x.BatchNo != null && x.BatchNo.ToLower().Contains(search.ToLower())).ToList();
                    //return context.Batches.Where(x => x.BatchNo != null &&
                    //     x.BatchNo.ToLower().Contains(search.ToLower()))
                    //     .OrderByDescending(x => x.MfgDate)
                    //     .Skip((pageNo - 1) * pageSize).Take(pageSize)
                    //     .Include(x => x.Product)
                    //     .Include(x => x.ProductBatchUsers)                         
                    //     .ToList();
                }
                if (PID.HasValue)
                {
                    batches = batches.Where(x => x.ProductId == PID.Value).ToList();
                }
                //else
                //{
                //    return context.Batches
                //        .OrderByDescending(X => X.MfgDate)
                //        .Skip((pageNo - 1) * pageSize)
                //        .Take(pageSize)
                //        .Include(x => x.Product)
                //        .Include(x => x.ProductBatchUsers)
                //        .ToList();
                //}
                return batches.OrderByDescending(x => x.MfgDate).Skip((pageNo - 1) * pageSize).Take(pageSize).ToList();
            }
        }
        public void UpdateBatch(Batch batch)
        {
            using (var context = new MHDbContext())
            {
                context.Entry(batch).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }
        public void DeleteBatch(int ID)
        {
            using (var context = new MHDbContext())
            {
                //var product = context.Products.Find(ID);
                var batch = context.Batches.Where(x => x.BID == ID).FirstOrDefault();
                // var category = context.Categories.Where(x => x.CID == ID).Include(x => x.Products).FirstOrDefault();

                //context.Products.RemoveRange(category.Products);  //first delete products of this category
                context.Batches.Remove(batch);
                context.SaveChanges();
            }
        }
        public List<Batch> GetBatches(List<int> IDs)
        {
            using (var context = new MHDbContext())
            {
                return context.Batches.Where(x => IDs.Contains(x.BID)).ToList();
            }
        }
    }
}
