using MH.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MH.Web.ViewModels
{
    public class CompanySearchViewModel
    {
        public List<Company> Companies { get; set; }
        public string SearchTerm { get; set; }

        public Pager Pager { get; set; }
    }

    public class NewCompanyViewModel
    {
        [Required]
        //[MinLength(5), MaxLength(50)]
        public string CmpName { get; set; }
        [Required]
        public string CRegisterName { get; set; }
        public string Address { get; set; }
        public int CompanyID { get; set; }
    }

    public class EditCompanyViewModel
    {
        public int CmpnyID { get; set; }
        public string CmpName { get; set; }
        public string CRegisterName { get; set; }
        public string Address { get; set; }
    }
    //public class CompanyViewModel
    //{
    //}
}