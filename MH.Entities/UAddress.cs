using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MH.Entities
{
    public class UAddress
    {
        [Key]
        public int AddressID { get; set; }
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser ApplicationUser { get; set; }

        public AddressType? Type { get; set; }
        public int? Upazilla { get; set; }//from Dropdown
        public string VillageOrTown { get; set; }
        public string RoadName { get; set; }
        public string HouseName { get; set; }
        public string HoldingNumber { get; set; }
        public string Flat { get; set; } 
    }
}
