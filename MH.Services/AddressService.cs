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
    public class AddressService
    {
        #region Singleton
        public static AddressService Instance
        {
            get
            {
                if (instance == null) instance = new AddressService();
                return instance;
            }
        }
        private static AddressService instance { get; set; }
        private AddressService()
        {

        }
        #endregion

        #region Country
        public void SaveCountry(Country country)
        {
            using (var context = new MHDbContext())
            {
                context.Countries.Add(country);
                context.SaveChanges();
            }
        }

        public List<Country> GetAllCountries()
        {
            using (var context = new MHDbContext())
            {
                return context.Countries.ToList();
            }
        }
        public Country GetCountry(int ID)
        {
            using (var context = new MHDbContext())
            {
                return context.Countries.Where(x=>x.CountryID==ID).FirstOrDefault();
                //return context.Countries.FirstOrDefault(x=>x.CountryID==ID);
                //return context.Countries.Find(ID);
            }
        }

        public int GetCountriesCount(string search)
        {
            using (var context = new MHDbContext())
            {
                if (!string.IsNullOrEmpty(search))
                {
                    return context.Countries.Where(country => country.Name != null &&
                         country.Name.ToLower().Contains(search.ToLower())).Count();
                }
                else
                {
                    return context.Countries.Count();
                }
            }
        }
       
        public List<Country> GetCountries(string search, int pageNo)
        {
            int pageSize = 10;

            using (var context = new MHDbContext())
            {
                if (!string.IsNullOrEmpty(search))
                {
                    return context.Countries.Where(country => country.Name != null &&
                         country.Name.ToLower().Contains(search.ToLower()))
                         .OrderBy(x => x.CountryID)
                         .Skip((pageNo - 1) * pageSize)
                         .Take(pageSize)
                         .Include(x => x.Divisions)
                         .ToList();
                }
                else
                {
                    return context.Countries
                        .OrderBy(x => x.CountryID)
                        .Skip((pageNo - 1) * pageSize)
                        .Take(pageSize)
                        .Include(x => x.Divisions)
                        .ToList();
                }
            }
        }

        public void UpdateCountry(Country country)
        {
            using (var context = new MHDbContext())
            {
                context.Entry(country).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        //public void DeleteCountry(int ID)
        //{
        //    using (var context = new MHDbContext())
        //    {
        //        //var category = context.Categories.Where(x => x.CID == ID).FirstOrDefault();
        //        var country = context.Countries.Where(x => x.CountryID == ID).Include("Divisions.Districts.Upazila").FirstOrDefault();

        //        context.Products.RemoveRange(country.Divisions);  //first delete products of this category
        //        context.Categories.Remove(category);
        //        context.SaveChanges();
        //    }
        //}

        #endregion

        #region Division
        public void SaveDivision(Division division)
        {
            using (var context = new MHDbContext())
            {
                context.Entry(division.Country).State = System.Data.Entity.EntityState.Unchanged;
                context.Divisions.Add(division);
                context.SaveChanges();
            }
        }
        public Division GetDivision(int ID)
        {
            using (var context = new MHDbContext())
            {
                return context.Divisions.FirstOrDefault(x => x.DivisionID== ID);
                //return context.Countries.Find(ID);
            }
        }
        public Division GetDivisionWithCountry(int ID)
        {
            using (var context = new MHDbContext())
            {
                return context.Divisions.Where(x=>x.DivisionID==ID).Include(x=>x.Country).FirstOrDefault();
                //return context.Countries.Find(ID);
            }
        }

        public int GetDivisionsCount(string search)
        {
            using (var context = new MHDbContext())
            {
                if (!string.IsNullOrEmpty(search))
                {
                    return context.Divisions.Where(division => division.Name != null &&
                         division.Name.ToLower().Contains(search.ToLower())).Count();
                }
                else
                {
                    return context.Divisions.Count();
                }
            }
        }
        public List<Division> GetAllDivisions()
        {
            using (var context = new MHDbContext())
            {
                return context.Divisions.ToList();
            }
        }
        public List<Division> GetDivisions(string search, int pageNo,int pageSize)
        {
            //int pageSize = 10;

            using (var context = new MHDbContext())
            {
                if (!string.IsNullOrEmpty(search))
                {
                    return context.Divisions.Where(division => division.Name != null &&
                         division.Name.ToLower().Contains(search.ToLower()))
                         .OrderBy(x => x.DivisionID)
                         .Skip((pageNo - 1) * pageSize)
                         .Take(pageSize)
                         .Include(x => x.Districts)
                         .Include(x=>x.Country)
                         .ToList();
                }
                else
                {
                    return context.Divisions
                        .OrderBy(x => x.DivisionID)
                        .Skip((pageNo - 1) * pageSize)
                        .Take(pageSize)
                        .Include(x => x.Districts)
                        .Include(x => x.Country)
                        .ToList();
                }
            }
        }

        public void UpdateDivision(Division division)
        {
            using (var context = new MHDbContext())
            {
                context.Entry(division).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        //public void DeleteDivision(int ID)
        //{
        //    using (var context = new MHDbContext())
        //    {
        //        //var category = context.Categories.Where(x => x.CID == ID).FirstOrDefault();
        //        var country = context.Countries.Where(x => x.CountryID == ID).Include("Divisions.Districts.Upazila").FirstOrDefault();

        //        context.Products.RemoveRange(country.Divisions);  //first delete products of this category
        //        context.Categories.Remove(category);
        //        context.SaveChanges();
        //    }
        //}
        #endregion

        #region District
        public void SaveDistrict(District district)
        {
            using (var context = new MHDbContext())
            {
                context.Entry(district.Division).State = System.Data.Entity.EntityState.Unchanged;
                context.Districts.Add(district);
                context.SaveChanges();
            }
        }
        public District GetDistrict(int ID)
        {
            using (var context = new MHDbContext())
            {
                return context.Districts.FirstOrDefault(x => x.DistrictID== ID);
                //return context.Countries.Find(ID);
            }
        }
        public District GetDistrictWithDivision(int ID)
        {
            using (var context = new MHDbContext())
            {
                return context.Districts.Where(x=>x.DistrictID==ID).Include(x=>x.Division).FirstOrDefault();
                //return context.Countries.Find(ID);
            }
        }

        public int GetDistrictsCount(string search)
        {
            using (var context = new MHDbContext())
            {
                if (!string.IsNullOrEmpty(search))
                {
                    return context.Districts.Where(district => district.Name != null &&
                         district.Name.ToLower().Contains(search.ToLower())).Count();
                }
                else
                {
                    return context.Districts.Count();
                }
            }
        }
        public List<District> GetAllDistricts()
        {
            using (var context = new MHDbContext())
            {
                return context.Districts.ToList();
            }
        }
        public List<District> GetDistricts(string search, int pageNo,int pageSize)
        {
            //int pageSize = 10;

            using (var context = new MHDbContext())
            {
                if (!string.IsNullOrEmpty(search))
                {
                    return context.Districts.Where(district => district.Name != null &&
                         district.Name.ToLower().Contains(search.ToLower()))
                         .OrderBy(x => x.DistrictID)
                         .Skip((pageNo - 1) * pageSize)
                         .Take(pageSize)
                         .Include(x => x.Upazila)
                         .Include(x=>x.Division)
                         .ToList();
                }
                else
                {
                    return context.Districts
                        .OrderBy(x => x.DistrictID)
                        .Skip((pageNo - 1) * pageSize)
                        .Take(pageSize)
                        .Include(x => x.Upazila)
                        .Include(x => x.Division)
                        .ToList();
                }
            }
        }

        //public List<District> GetDistrictsForTEST(string search, int pageNo, int pageSize)
        //{
        //    //int pageSize = 10;

        //    using (var context = new MHDbContext())
        //    {
        //        if (!string.IsNullOrEmpty(search))
        //        {
        //            return context.Districts.Where(district => district.Name != null &&
        //                 district.Name.ToLower().Contains(search.ToLower()))
        //                 .OrderBy(x => x.DistrictID)
        //                 .Skip((pageNo - 1) * pageSize)
        //                 .Take(pageSize)
        //                 .Include(x => x.Upazila)
        //                 .Include(x => x.Division)
        //                 .ToList();
        //            //var a= (from country in context.Countries
        //            //      from division in country.Divisions
        //            //      from district in division.Districts
        //            //      //from upazilla in district.Upazila
        //            //      select new
        //            //      {
        //            //          CountryName = country.Name,
        //            //          DivisionName = division.Name,
        //            //          DistrictName = district.Name,
        //            //          DistrictID = district.DistrictID,
        //            //          Upazilla = district.Upazila

        //            //      }).Where(x=>x.DistrictName != null && x.DistrictName.ToLower().Contains(search.ToLower()))
        //            //      .OrderBy(x=>x.DistrictID)
        //            //      .Skip((pageNo - 1) * pageSize)
        //            //      .Take(pageSize)
        //            //      .ToList();
        //            //return null;

        //        }
        //        else
        //        {
        //            return context.Districts
        //                .OrderBy(x => x.DistrictID)
        //                .Skip((pageNo - 1) * pageSize)
        //                .Take(pageSize)
        //                .Include(x => x.Upazila)
        //                .ToList();
        //        }
        //    }
        //}

        public void UpdateDistrict(District district)
        {
            using (var context = new MHDbContext())
            {
                context.Entry(district).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        //public void DeleteDivision(int ID)
        //{
        //    using (var context = new MHDbContext())
        //    {
        //        //var category = context.Categories.Where(x => x.CID == ID).FirstOrDefault();
        //        var country = context.Countries.Where(x => x.CountryID == ID).Include("Divisions.Districts.Upazila").FirstOrDefault();

        //        context.Products.RemoveRange(country.Divisions);  //first delete products of this category
        //        context.Categories.Remove(category);
        //        context.SaveChanges();
        //    }
        //}
        #endregion

        #region Upazila
        public void SaveUpazila(Upazila upazila)
        {
            using (var context = new MHDbContext())
            {
                context.Entry(upazila.District).State = System.Data.Entity.EntityState.Unchanged;
                context.Upazilas.Add(upazila);
                context.SaveChanges();
            }
        }
        public Upazila GetUpazila(int ID)
        {
            using (var context = new MHDbContext())
            {
                return context.Upazilas.FirstOrDefault(x => x.UpazilaID == ID);
                //return context.Countries.Find(ID);
            }
        }
        public Upazila GetUpazilaWithDistric(int ID)
        {
            using (var context = new MHDbContext())
            {
                return context.Upazilas.Where(x => x.UpazilaID == ID).Include(x => x.District).FirstOrDefault();
                //return context.Countries.Find(ID);
            }
        }

        public int GetUpazilasCount(string search)
        {
            using (var context = new MHDbContext())
            {
                if (!string.IsNullOrEmpty(search))
                {
                    return context.Upazilas.Where(upazila => upazila.Name != null &&
                         upazila.Name.ToLower().Contains(search.ToLower())).Count();
                }
                else
                {
                    return context.Upazilas.Count();
                }
            }
        }
        public List<Upazila> GetAllUpazila()
        {
            using (var context = new MHDbContext())
            {
                return context.Upazilas.ToList();
            }
        }
        public List<Upazila> GetUpazilas(string search, int pageNo, int pageSize)
        {
            //int pageSize = 10;

            using (var context = new MHDbContext())
            {
                if (!string.IsNullOrEmpty(search))
                {
                    return context.Upazilas.Where(upazila => upazila.Name != null &&
                         upazila.Name.ToLower().Contains(search.ToLower()))
                         .OrderBy(x => x.UpazilaID)
                         .Skip((pageNo - 1) * pageSize)
                         .Take(pageSize)
                         .Include(x => x.District)
                         .ToList();
                }
                else
                {
                    return context.Upazilas
                        .OrderBy(x => x.UpazilaID)
                        .Skip((pageNo - 1) * pageSize)
                        .Take(pageSize)
                        .Include(x => x.District)
                        .ToList();
                }
            }
        }

        public void UpdateUpazila(Upazila upazila)
        {
            using (var context = new MHDbContext())
            {
                context.Entry(upazila).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        //public void DeleteDivision(int ID)
        //{
        //    using (var context = new MHDbContext())
        //    {
        //        //var category = context.Categories.Where(x => x.CID == ID).FirstOrDefault();
        //        var country = context.Countries.Where(x => x.CountryID == ID).Include("Divisions.Districts.Upazila").FirstOrDefault();

        //        context.Products.RemoveRange(country.Divisions);  //first delete products of this category
        //        context.Categories.Remove(category);
        //        context.SaveChanges();
        //    }
        //}
        #endregion

    }
}
