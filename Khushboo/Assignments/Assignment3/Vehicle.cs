
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace VehicleSystem
{
    public class Vehicle
    {
        // 1. Readonly properties
        public readonly string VehicleName;
        public readonly string FuelType;

        // 2. Const field
        public const string ProductionLineNumber = "PLN-2025";

        // 3. Get-only property
        public string VehicleVersion { get; } = "v1.0";

        // 4. Constructor1: Takes only Vehicle Name
        public Vehicle(string name) : this(name, "Petrol") // 6. Calls Constructor2 using this
        {
        }

        // 5. Constructor2: Takes Vehicle Name and FuelType
        public Vehicle(string name, string fuel)
        {
            VehicleName = name;
            FuelType = fuel;
        }

        public void ShowDetails()
        {
            Console.WriteLine($"Name: {VehicleName}, Fuel: {FuelType}, Version: {VehicleVersion}, Line: {ProductionLineNumber}");
        }
    }
}

