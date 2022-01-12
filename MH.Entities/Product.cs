using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        [ForeignKey("CategoryID")]
        public virtual Category Category { get; set; }

        public int CompanyID { get; set; }
        [ForeignKey("CompanyID")]
        public virtual Company Company { get; set; }

        public List<Batch> Batches { get; set; }
        public IList<ProductState> ProductStates { get; set; }
    }
}
