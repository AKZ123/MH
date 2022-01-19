using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MH.Entities
{
    public enum Genders : short
    {
        Male = 1,
        Female = 2,
        Unknown = 3
    }
    public enum ProductStatus : short
    {
        Unavailable = 0,
        Available = 1
    }
    public enum AreaStatus : short
    {
        Unactive = 0,
        Active = 1
    }
    class Common
    {
    }
}
