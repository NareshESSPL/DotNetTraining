using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTypes
{
    public class PropertyExapmle
    {
        // Private field
        private string name;

        // Property for accessing the private field
        public string Name
        {
            get { return name; } // Getter - retrieves the value
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    name = value; // Setter - sets the value
                }
                else
                {
                    Console.WriteLine("Name cannot be empty.");
                }
            }
        }

        /*
         * With Arrow operator         
        */
        // Private field
        private decimal price;

        // Public property with arrow operator
        public decimal Price
        {
            get => price; // Getter - retrieves the value of price
            set => price = (value >= 0)
                ? value
                : throw new ArgumentException("Price cannot be negative."); // Setter - sets the value with validation
        }

        // Auto-implemented property
        public int Age { get; set; } // No explicit backing field needed


        //Read-Only Properties:
        public string ReadOnlyProperty { get; } = "Fixed Value";



        public void TestProperty()
        {

        }

    }
}
