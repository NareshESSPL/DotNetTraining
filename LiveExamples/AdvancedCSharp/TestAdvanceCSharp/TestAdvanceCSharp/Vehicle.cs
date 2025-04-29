using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAdvanceCSharp
{
    public class Vehicle
    {
        public readonly string VehicleName;
        public readonly string FuelType;

        public const int ProductionLineNumber = 101;

        public string VehicleVersion => "V1.0";

        public Vehicle(string vehicleName) : this(vehicleName, "Petrol") 
        {
        }

        public Vehicle(string vehicleName, string fuelType)
        {
            VehicleName = vehicleName;
            FuelType = fuelType;
        }
    }
    public class VehicleLimitedEdition : Vehicle
    {
        public VehicleLimitedEdition(string name, string fuel) : base(name, fuel) { }
    }
}
