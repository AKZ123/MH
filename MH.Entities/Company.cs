using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MH.Entities
{
    public class Company
    {
        [Key]
        public int CmpnyID { get; set; }
        public string CmpName { get; set; }
        public string CRegisterName { get; set; }
        public string Address { get; set; }

        public List<Product> Products { get; set; }
    }
}
