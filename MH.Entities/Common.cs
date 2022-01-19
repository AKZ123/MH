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
    public enum AddressType : short
    {
        Permanent = 0,    
        Present = 1
    }
    public enum Flore : short
    {
        Upon_10 = 10,
        Upon_9 = 9,
        Upon_8 = 8,
        Upon_7 = 7,
        Upon_6 = 6,
        Upon_5 = 5,
        Upon_4 = 4,
        Upon_3 = 3,
        Upon_2 = 2,
        Upon_1 = 1,
        Ground = 0,
        Ground_1 = -1,
        Ground_2 = -2,
        Ground_3 = -3,
        Ground_4 = -4,
        Ground_5 = -5
    }
    public enum UserStatus : short
    {
        Owner = 0,
        Manager = 1,
        Employee = 2
    }
    //class Common
    //{
    //}
}
