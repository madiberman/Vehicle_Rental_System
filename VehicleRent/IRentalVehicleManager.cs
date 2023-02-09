using System;
namespace VehicleRent
{
    interface IRentalVehicleManager
    {
        public bool addVehicle(Vehicle addVeh);
        public bool deleteVehicle(string reg);
        public void listVehicles();
        public void listVehiclesOrdered();
        public void generateReport(string fileName);
    }
}
