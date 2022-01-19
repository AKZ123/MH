using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MH.Entities
{
    public class UserSaleArea
    {
        [Key, Column(Order = 1)]
        public int SaleAreaId { get; set; }
        [ForeignKey("SaleAreaId")]
        public virtual SaleArea SaleAreas { get; set; }


        [Key, Column(Order = 2)]
        public string UserID { get; set; }
        [ForeignKey("UserID")]
        public virtual ApplicationUser Users { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public AreaStatus AreaStatus { get; set; }
    }
}
