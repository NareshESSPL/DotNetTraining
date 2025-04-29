using VehicleManagementSystem;
namespace VMSTest;

    public class Program
    {
        static void Main(string[] args)
        {
            Vehicle car = new Vehicle("Honda City");
            Console.WriteLine($"Vehicle Name: {car.vehicleName}");
            Console.WriteLine($"Fuel Type: {car.FuelType}");
            Console.WriteLine($"Production Line: {Vehicle.ProductionLineNumber}");
            Console.WriteLine($"Vehicle Version: {car.VehicleVersion}");

            Console.WriteLine("---------------------------------");

            VehicleLimitedEdition limitedCar = new VehicleLimitedEdition("Honda Civic", "Diesel");
            Console.WriteLine($"Limited Edition Vehicle Name: {limitedCar.vehicleName}");
            Console.WriteLine($"Fuel Type: {limitedCar.FuelType}");
            Console.WriteLine($"Production Line: {VehicleLimitedEdition.ProductionLineNumber}");
            Console.WriteLine($"Vehicle Version: {limitedCar.VehicleVersion}");

            Console.ReadLine();
        }
    }

