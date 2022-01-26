using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using MH.Entities;

namespace MH.Web.ViewModels
{
    public class RoleViewModel
    {
        public RoleViewModel()
        {
        }
        public RoleViewModel(ApplicationRole role)
        {
            Id = role.Id;
            Name = role.Name;
        }

        public string Id { get; set; }
        [Required]
        public string Name { get; set; } 
    }

    public class RoleSearchViewModel
    {
        public List<RoleViewModel> VMRoles { get; set; }
        public string SearchTerm { get; set; }

        public Pager Pager { get; set; }
    }

    //public class NewRoleViewModel
    //{
    //    public string Name { get; set; }
    //}

    public class EditRoleViewModel
    {
        public int ID { get; set; }

        public string Name { get; set; }
    }
}