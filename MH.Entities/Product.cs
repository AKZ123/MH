using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MH.Entities
{
    public class Product
    {
        [Key]
        public int PID { get; set; }
        public string Name { get; set; }
        public decimal MrpPrice { get; set; }
        public int PackSize { get; set; }
        public string Description { get; set; }


        public Category Category { get; set; }
    }
}
