using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    public class Vehicle
    {
        public readonly string? VehicleName;
        public readonly string? FuelType;

        public const int LineNumber = 10;

        public string vehicleVersion
        {
            get => vehicleVersion;
        }
        public Vehicle(string name)
        {
            VehicleName = name;
        }
        public Vehicle(string name, string type )
        {
            this.VehicleName = name;
            this.FuelType = type;

            Console.WriteLine(VehicleName + " " + FuelType);
        }

    }
}
