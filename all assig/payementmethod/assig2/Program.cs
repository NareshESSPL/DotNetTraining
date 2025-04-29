using System;

namespace VehicleNamespace
{
   
    public class Vehicle
    {
        
        public string VehicleName { get; }
        public string FuelType { get; }

 
        public const string ProductionLineNumber = "PLN-1234";

  
        public string VehicleVersion
        {
            get { return "V1.0"; }
        }

        
        public Vehicle(string vehicleName)
            : this(vehicleName, "Petrol")   
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
      
        public VehicleLimitedEdition(string vehicleName, string fuelType)
            : base(vehicleName, fuelType)  
        {
        }
    }

    
    class Program
    {
        static void Main(string[] args)
        {
             
            Vehicle vehicle = new Vehicle("Honda City");
            Console.WriteLine($"Vehicle Name: {vehicle.VehicleName}");
            Console.WriteLine($"Fuel Type: {vehicle.FuelType}");
            Console.WriteLine($"Production Line Number: {Vehicle.ProductionLineNumber}");
            Console.WriteLine($"Vehicle Version: {vehicle.VehicleVersion}");
            Console.WriteLine();

            
            VehicleLimitedEdition limitedVehicle = new VehicleLimitedEdition("Audi A6", "Diesel");
            Console.WriteLine($"Limited Edition Vehicle Name: {limitedVehicle.VehicleName}");
            Console.WriteLine($"Fuel Type: {limitedVehicle.FuelType}");
            Console.WriteLine($"Production Line Number: {Vehicle.ProductionLineNumber}");
            Console.WriteLine($"Vehicle Version: {limitedVehicle.VehicleVersion}");
        }
    }
}
