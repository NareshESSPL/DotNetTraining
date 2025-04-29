using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPsConcept
{
    public enum ItemType
    {
        None,
            Grocery,
            Fashion,
            Healthcare,
            Travel
    }

    public class ItemTypeOps
    {
        public void PrintItemTyype(int ItemTypeId)
        {
            //if (ItemTypeId == (int)ItemType.Grocery)
            //{
            //    Console.WriteLine("Grocery");
            //}
            switch (ItemTypeId)
            {
                case (int)ItemType.Grocery:
                    Console.WriteLine("Grocery");
                    break;

                case (int)ItemType.Fashion:
                    Console.WriteLine("Fashion");
                    break;

                case (int)ItemType.Healthcare:
                    Console.WriteLine("Healthcare");
                    break;

                case (int)ItemType.Travel:
                    Console.WriteLine("Travel");
                    break;

                default:
                    Console.WriteLine("Unknown Item Type");
                    break;
            }
        }
    }
   
}
