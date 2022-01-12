using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MH.Entities
{
    public class Order
    {
        [Key]
        public int OID { get; set; }
        public DateTime OrderedAt { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; }
        public DateTime Delivery { get; set; }


        //public string UserID { get; set; }
        //public string OwnerID { get; set; }
         public virtual List<OrderItem> OrderItems { get; set; }
    }
}
