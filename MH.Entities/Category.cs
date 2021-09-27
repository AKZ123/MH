using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MH.Entities
{
    public class Category
    {
        public int CID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }


        public List<Product> Products { get; set; }

    }
}
