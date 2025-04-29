namespace VehicleManagementSystem
{
    public class Vehicle
    {
        public readonly string? vehicleName;
        public readonly string? FuelType;
        public const int ProductionLineNumber = 101;
        public string VehicleVersion
        {
            get { return "V1.0"; }
        }
        public Vehicle(string vehicleName) : this(vehicleName , "petrol")
        {


        }
        public Vehicle(string vehicleName,string FuelType)
        {
            this.vehicleName = vehicleName;
            this.FuelType = FuelType;
        }

    }
}
