using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MH.Entities
{
    public class Store
    {
        [Key]
        public int StoreID { get; set; }
        public string StoreNong { get; set; }
        public string Name { get; set; }
        public string MapLocation { get; set; }
        public string TradLicenID { get; set; }
        public string TradLicenPic { get; set; }
        public string PSellLicenID { get; set; }
        public string PSellLicenPic { get; set; }
        //Address
        public int Upazilla { get; set; }//from Dropdown
        public string VillageOrTown { get; set; }
        public string RoadName { get; set; }
        public string MarketName { get; set; }
        public Flore Flore { get; set; }
        public string Position { get; set; }

        public virtual List<UserStore> StoreUser { get; set; }
    }
}
