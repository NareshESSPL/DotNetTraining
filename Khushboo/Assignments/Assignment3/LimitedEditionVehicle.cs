using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace VehicleSystem
{
    public class LimitedEditionVehicle : Vehicle
    {
        // 6. Constructor3: Uses base to call Vehicle constructor2
        public LimitedEditionVehicle(string name, string fuel) : base(name, fuel)
        {
        }

        public void ShowLimitedEditionFeature()
        {
            Console.WriteLine($"[LIMITED EDITION] {VehicleName} - {FuelType} - {VehicleVersion} (Line {ProductionLineNumber})");
        }
    }
}

