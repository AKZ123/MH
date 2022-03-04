using MH.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MH.Web.ViewModels
{
    public class NameViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
    #region Country
    public class CountrySearchViewModel
    {
        public List<Country> Countries { get; set; }
        public string SearchTerm { get; set; }

        public Pager Pager { get; set; }
    }

    public class NewCountryViewModel
    {
        [Required]
        //[MinLength(5), MaxLength(50)]
        public string Name { get; set; }
        public string ISOCountryCode { get; set; }
        public string DialingCoad { get; set; }
        public int CountryID { get; set; }
    }

    public class EditCountryViewModel
    {
        public int ID { get; set; }

        public string Name { get; set; }
        public string ISOCountryCode { get; set; }
        public string DialingCoad { get; set; }

    }
    #endregion

    #region Division
    public class DivisionSearchViewModel
    {
        public List<Division> Divisions { get; set; }
        public string SearchTerm { get; set; }

        public Pager Pager { get; set; }
    }
    public class NewDivisionViewModel
    {
        public string Name { get; set; }
        public int CountryID { get; set; }
        public List<Country> AvailableCountries { get; set; }
    }
    public class EditDivisionViewModel
    {
        public int DivisionID { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }
        public List<Country> AvailableCountries { get; set; }
        //public int CompanyID { get; set; }
        //public List<Company> AvailableCompanies { get; set; }
    }
    #endregion
    #region District
    public class DistrictSearchViewModel
    {
        //public int PageNo { get;  set; }
        public List<District> Districts { get; set; }
        public string SearchTerm { get; set; }

        public Pager Pager { get; set; }
    }
    public class NewDistrictViewModel
    {
        public string Name { get; set; }
        public int DivisionID { get; set; }
        public List<Division> AvailableDivisions { get; set; }
    }
    public class EditDistrictViewModel
    {
        public int DistrictID { get; set; }
        public string Name { get; set; }
        public int DivisionID { get; set; }
        public List<Division> AvailableDivisions { get; set; }
    }

    #endregion
    #region Upazila
    public class UpazilaSearchViewModel
    {
        //public int PageNo { get;  set; }
        public List<Upazila> Upazilas { get; set; }
        public string SearchTerm { get; set; }

        public Pager Pager { get; set; }
    }
    public class NewUpazilaViewModel
    {
        public string Name { get; set; }
        //public int CategoryID { get; set; }
        public int DistrictID { get; set; }
        public List<District> AvailableDistricts { get; set; }
        //public List<Company> AvailableCompanies { get; set; }
    }
    public class EditUpazilaViewModel
    {
        public int UpazilaID { get; set; }
        public string Name { get; set; }
        //public int CategoryID { get; set; }
        //public List<Category> AvailableCategories { get; set; }
        public int DistrictID { get; set; }
        public List<District> AvailableDistricts { get; set; }
    }
    public class UpazilaViewModel
    {
        public Upazila Upazila { get; set; }
    }
    #endregion
}