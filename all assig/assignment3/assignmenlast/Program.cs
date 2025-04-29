using System;

public class Vehicle
{
 
    public readonly string VehicleName;
    public readonly string FuelType;

   
    public const int ProductionLineNumber = 1001;
 
    public string VehicleVersion { get; } = "V1.0";

  
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
   
    public VehicleLimitedEdition(string vehicleName, string fuelType)
        : base(vehicleName, fuelType)   
    {
        Console.WriteLine("Limited Edition Vehicle Created");
    }
}

 
class Program
{
    static void Main()
    {
        Vehicle vehicle = new Vehicle("Sedan");
        Console.WriteLine($"Vehicle Name: {vehicle.VehicleName}, Fuel Type: {vehicle.FuelType}, Version: {vehicle.VehicleVersion}, Line: {Vehicle.ProductionLineNumber}");

        VehicleLimitedEdition limited = new VehicleLimitedEdition("SUV", "Diesel");
        Console.WriteLine($"Vehicle Name: {limited.VehicleName}, Fuel Type: {limited.FuelType}, Version: {limited.VehicleVersion}, Line: {Vehicle.ProductionLineNumber}");
    }
}
