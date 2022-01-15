using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MH.Entities
{
    public class Division
    {
        [Key]
        public int DivisionID { get; set; }
        public string Name { get; set; }

        public int CountryId { get; set; }
        [ForeignKey("CountryId")]
        public virtual Country Country { get; set; }
        public virtual List<District> Districts { get; set; }
    }
}
