using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MH.Entities
{
    public class SaleArea
    {
        [Key]
        public int SAID { get; set; }
        public string Name { get; set; }
        public DateTime AreaIncreaseDate { get; set; } 

        public virtual IList<UserSaleArea> UserSaleAreas { get; set; }
    }
}
