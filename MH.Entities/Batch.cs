using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MH.Entities
{
    public class Batch
    {
        [Key]
        public int BID { get; set; }
        public string BatchNo { get; set; }
        public DateTime MfgDate { get; set; }
        public DateTime ExpDate { get; set; }
        public decimal Mrp { get; set; }

        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }

        public virtual IList<OrderItem> OrderItems { get; set; }

    }
}
