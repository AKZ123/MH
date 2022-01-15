using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MH.Entities
{
    public class District
    {
        [Key]
        public int DistrictID { get; set; }
        public string Name { get; set; }

        public int DivisionId { get; set; }
        [ForeignKey("DivisionId")]
        public virtual Division Division { get; set; }
        public virtual List<Upazila> Upazila { get; set; }
    }
}
