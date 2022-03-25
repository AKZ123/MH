using MH.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MH.Web.ViewModels
{
    public class UserViewModel
    {
        public string RoleID { get; set; }
        public string SearchTerm { get; set; }
        public string PhoneNumber { get; set; }
        //public List<IdentityRole> Roles { get; set; }
        public List<ApplicationRole> Roles { get; set; }
        public int? PageNo { get; set; }
    }

    public class UsersListingViewModel
    {
        public List<ApplicationUser> Users { get; set; }
        public string RoleID { get; set; }
        public string SearchTerm { get; set; }
        public string PhoneNumber { get; set; }
        public Pager Pager { get; set; }
        public int? PageNo { get; set; }
    }
    public class UsersDetailViewModel
    {
        public ApplicationUser User { get; set; }
    }

    public class UserRolesViewModel
    {
        public List<ApplicationRole> AvailableRoles { get; internal set; }
        public ApplicationUser User { get; internal set; }
        public IEnumerable<ApplicationRole> UserRoles { get; internal set; }
    }
    public class UserAddressIndexViewModel
    {        
        public ApplicationUser user { get; internal set; }
    }
    public class UserAddressListingViewModel
    {
        public List<UAddressView> UAddressesView { get; internal set; }
        //public List<UAddress> UAddresses { get; internal set; }
        public ApplicationUser User { get; internal set; }
        //public IEnumerable<AddressType> AddressTypes { get; internal set; }
    }
    public class UAddressView
    {
        public int AddressID { get; set; }
        //public string UserId { get; set; }       
        public AddressType? Type { get; set; }
        public string UpazillaName { get; set; }
        public string VillageOrTown { get; set; }
        public string RoadName { get; set; }
        public string HouseName { get; set; }
        public string HoldingNumber { get; set; }
        public string Flat { get; set; }
    }
    public class UserAddressAddViewModel
    {
        [Required]
        public AddressType? Type { get; set; }
        [Required]
        public int? Upazilla { get; set; }
        [Required]
        public string VillageOrTown { get; set; }
        public string RoadName { get; set; }
        public string HouseName { get; set; }
        public string HoldingNumber { get; set; }
        public string Flat { get; set; }
        //public UAddress uAddress { get;  set; }
        public List<NameViewModel> addressType { get; set; }
        public List<Country> AvailableCountrys { get; set; }
        //public List<Division> AvailableDivisiones { get; set; }
        //public List<District> AvailableDistrictes { get; set; }
        //public List<Upazila> AvailableUpazilas { get; set; }

        public string UserId { get; set; }
        public ApplicationUser User { get;  set; }
        //public Country Country { get;  set; }
        //public Division Division { get;  set; }
        //public District District { get;  set; }
        //public Upazila Upazila { get;  set; }
        //public int CounteyID { get; set; }
        //public int DivisionID { get; set; }
        //public int DistrictID { get; set; }
        //public int UpazilaID { get; set; }

    }
}