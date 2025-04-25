using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPS
{
    public enum Itemtype
    {
        None,
        Grocery,
        Fashion,
        Healthcare,
        Travel
    }

    public class ItemTypeOps
    {
        public void PrintItemType(int ItmeTypeId)
        {
            if (ItmeTypeId == (int)Itemtype.Grocery)
                Console.WriteLine("Grocery");

        }
    }
}

//categrory
//categoryID catergoryName 
//  1        Grocery
//  2        Fashion
//  3        Healthcare
//  4        Travel