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
    public class CompaniesService
    {
        #region Singleton
        public static CompaniesService Instance
        {
            get
            {
                if (instance == null) instance = new CompaniesService();
                return instance;
            }
        }
        private static CompaniesService instance { get; set; }
        private CompaniesService()
        {

        }
        //////////
        #endregion
        public void SaveCompany(Company company)
        {
            using (var context = new MHDbContext())
            {
                context.Companies.Add(company);
                context.SaveChanges();
            }
        }
        /// //
        public Company GetCompany(int ID)
        {
            using (var context = new MHDbContext())
            {
                return context.Companies.Find(ID);
            }
        }
        /// /////
        public int GetCompaniesCount(string search)
        {
            using (var context = new MHDbContext())
            {
                if (!string.IsNullOrEmpty(search))
                {
                    return context.Companies.Where(company => company.CmpName != null &&
                         company.CmpName.ToLower().Contains(search.ToLower())).Count();
                }
                else
                {
                    return context.Companies.Count();
                }
            }
        }
        public List<Company> GetAllCompanies()
        {
            using (var context = new MHDbContext())
            {
                return context.Companies.ToList();
            }
        }
        /// ////
        public List<Company> GetCompanies(string search, int pageNo)
        {
            int pageSize = 10;

            using (var context = new MHDbContext())
            {
                if (!string.IsNullOrEmpty(search))
                {
                    return context.Companies.Where(company => company.CmpName != null &&
                         company.CmpName.ToLower().Contains(search.ToLower()))
                         .OrderBy(x => x.CmpnyID)
                         .Skip((pageNo - 1) * pageSize)
                         .Take(pageSize)
                         .Include(x => x.Products)
                         .ToList();
                }
                else
                {
                    return context.Companies
                        .OrderBy(x => x.CmpnyID)
                        .Skip((pageNo - 1) * pageSize)
                        .Take(pageSize)
                        .Include(x => x.Products)
                        .ToList();
                }
            }
        }
        //  /////
        public void UpdateCompany(Company company)
        {
            using (var context = new MHDbContext())
            {
                context.Entry(company).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }
        //  ///
        public void DeleteCompany(int ID)
        {
            using (var context = new MHDbContext())
            {
                //var category = context.Categories.Where(x => x.CID == ID).FirstOrDefault();
                var company = context.Companies.Where(x => x.CmpnyID == ID).Include(x => x.Products).FirstOrDefault();

                context.Products.RemoveRange(company.Products);  //first delete products of this category
                context.Companies.Remove(company);
                context.SaveChanges();
            }
        }

    }
}
