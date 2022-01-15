using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MH.Entities
{
    public class Country
    {
        [Key]
        public int CountryID { get; set; }
        public string Name { get; set; }
        public string ISOCountryCode { get; set; }
        public string DialingCoad { get; set; }
        public virtual List<Division> Divisions { get; set; }
    }
}
