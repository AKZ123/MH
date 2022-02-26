using MH.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
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
}