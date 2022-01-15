using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MH.Entities
{
    public class Upazila
    {
        [Key]
        public int UpazilaID { get; set; }
        public string Name { get; set; }

        public int DistrictId { get; set; }
        [ForeignKey("DistrictId")]
        public virtual District District { get; set; }
    }
}
