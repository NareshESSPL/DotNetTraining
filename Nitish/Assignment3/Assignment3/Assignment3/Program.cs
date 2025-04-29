using ClassLibrary;
namespace Assignment3
{
    class Program
    {
        static void Main()
        {
            var normalVehicle = new Vehicle("Nissan");
            Console.WriteLine($"Normal Vehicle: {normalVehicle.VehicleName}, Fuel: {normalVehicle.FuelType}, Version: {normalVehicle.Version}, Line: {Vehicle.ProductionLineNumber}");

            var limitedVehicle = new VehicleLimitedEdition("Tesla Roadster", "Electric");
            Console.WriteLine($"Limited Edition: {limitedVehicle.VehicleName}, Fuel: {limitedVehicle.FuelType}, Version: {limitedVehicle.Version}, Line: {Vehicle.ProductionLineNumber}");
        }
    }

}
