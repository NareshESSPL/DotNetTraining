namespace VehicleLimitedEdition
{
    public class Vehicle
    {
        public readonly string VehicleName;

        public string FuelType;
        public string vehicleVersion = "1.3.5.3";

        internal string VehicleVersion
        {
            get
            {
                return vehicleVersion;
            }
        }

        internal const int VehicleProductionLineNumber = 296322;



        public Vehicle(string VehicleName)
        {
            this.VehicleName = VehicleName;
        }

        public Vehicle(string? VehicleName, string FuelType) : this(VehicleName)
        {

            //this.VehicleName=VehicleName;
            this.FuelType = FuelType;
        }

    }


    public class VehicleLimitedEdition : Vehicle
    {
        public string VehicleName { get; set; }

        public VehicleLimitedEdition(string VehicleName, string FuelType) : base(VehicleName, FuelType)
        {
        }

    }

    public class VehicleInfo
    {
        public void VehicleDetails()
        {
            //Vehicle vehicle = new Vehicle("FZ-S");
            Vehicle vehicle1 = new Vehicle("Pulsar", "Diesel");

            Console.Write($" Vehicle Name is : {vehicle1.VehicleName}");
            Console.Write($" Vehicle Version is : {vehicle1.vehicleVersion}");
            Console.Write($" Vehicle Fuel Type is : {vehicle1.FuelType}");



        }


    }
}
