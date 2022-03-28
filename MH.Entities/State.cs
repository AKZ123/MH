using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MH.Entities
{
    public class State
    {
        [Key]
        public int SID { get; set; }
        public string StateName { get; set; }
        public string PackSizeUnit { get; set; }        
        public List<Product> Products { get; set; }
        //public IList<ProductState> ProductStates { get; set; }
    }
}
