namespace ClassLibrary
{
    //using System;

    public class Vehicle
    {
        // 1. Readonly properties
        public readonly string VehicleName;
        public readonly string FuelType;

        // 2. Constant field
        public const string ProductionLineNumber = "PLN-2024-IND";

        // 3. Read-only property with only get (backed internally)
        private string _version = "v1.0";
        public string Version => _version;

        // 4. Constructor 1: accepts only vehicle name
        public Vehicle(string vehicleName) : this(vehicleName, "Petrol") // 6. Call constructor2 using "this"
        {
        }

        // 5. Constructor 2: accepts vehicle name and fuel type
        public Vehicle(string vehicleName, string fuelType)
        {
            VehicleName = vehicleName;
            FuelType = fuelType;
        }
    }
    public class VehicleLimitedEdition : Vehicle
    {
        // 6. Constructor 3: calls base constructor using "base"
        public VehicleLimitedEdition(string vehicleName, string fuelType)
            : base(vehicleName, fuelType)
        {
            // Additional logic for limited edition can be added here
        }
    }


}
