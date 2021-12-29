using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MH.Entities
{
    public class Product
    {
        [Key]
        public int PID { get; set; }
        public string BrandName { get; set; }
        public string Strength { get; set; }
        public string GenericName { get; set; }
        public string MfgLicNo { get; set; }
        //Drag Administration Registration Number
        public string DARNo { get; set; }
        public string ImageURL { get; set; }
        //public decimal MrpPrice { get; set; }
        public int PackSize { get; set; }


        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }

        public int CompanyID { get; set; }
        public virtual Company Company { get; set; }
    }
}
