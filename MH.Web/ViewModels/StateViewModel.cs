using MH.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MH.Web.ViewModels
{
    public class StateSearchViewModel
    {
        public List<State> States { get; set; }
        public string SearchTerm { get; set; }

        public Pager Pager { get; set; }
    }

    public class NewStateViewModel
    {
        [Required]
        [MinLength(1), MaxLength(20)]
        public string Name { get; set; }
        [MaxLength(20)]
        public string Unit { get; set; }
    }

    public class EditStateViewModel
    {
        [Required]
        public int ID { get; set; }
        [Required]
        [MinLength(1), MaxLength(20)]
        public string Name { get; set; }
        [MaxLength(20)]
        public string Unit { get; set; }
    }
    //public class StateViewModel
    //{
    //    public State State { get; set; } 
    //}
}