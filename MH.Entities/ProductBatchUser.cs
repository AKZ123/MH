using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MH.Entities
{
    public enum Statuses : short
    {
        Available = 1,
        Unavailable = 0
    }
    public class ProductBatchUser
    {
        [Key,Column(Order =1)]
        public int BatchId { get; set; }
        [ForeignKey("BatchId")]
        public virtual Batch Batch { get; set; }


        [Key, Column(Order = 2)]
        public string UserID { get; set; }
        [ForeignKey("UserID")]
        public virtual ApplicationUser Users { get; set; }


        public string Stocks { get; set; }
        public DateTime EnrollDate { get; set; }
        public Statuses Status { get; set; }
        public decimal Percentage { get; set; }
    }
}
