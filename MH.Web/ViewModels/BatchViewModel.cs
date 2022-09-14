using MH.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MH.Web.ViewModels
{
    public class BatchViewModel
    {
    }
    public class BatchSearchViewModel
    {
        //public int PageNo { get;  set; }
        public List<Batch> Batches { get; set; }
        public string SearchTerm { get; set; }

        public Pager Pager { get; set; }
    }
    public class NewBatchViewModel
    {
        [Required]
        public string BatchNo { get; set; }
        [Required]
        public DateTime MfgDate { get; set; }
        [Required]
        public DateTime ExpDate { get; set; }
        [Required]
        public decimal Mrp { get; set; }

        public int ProductId { get; set; }
    }
    //public class EditProductViewModel
    //{
    //    public int PID { get; set; }
    //    public string BrandName { get; set; }
    //    public string Strength { get; set; }
    //    public string GenericName { get; set; }
    //    public string MfgLicNo { get; set; }
    //    public string DARNo { get; set; }
    //    public string ImageURL { get; set; }
    //    public int PackSize { get; set; }
    //    public int CategoryID { get; set; }
    //    public List<Category> AvailableCategories { get; set; }
    //    public int CompanyID { get; set; }
    //    public List<Company> AvailableCompanies { get; set; }
    //    public int StateID { get; set; }
    //    public List<State> AvailableStates { get; set; }
    //}
    //public class ProductViewModel
    //{
    //    public Product Product { get; set; }
    //}
}