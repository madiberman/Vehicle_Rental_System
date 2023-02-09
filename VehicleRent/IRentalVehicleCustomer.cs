using System;
namespace VehicleRent
{
    interface IRentalVehicleCustomer
    {
        public void listAvailableVehicles(Schedule wantedSchedule, VehicleType type);
        public bool rentVehicle(string RegistrationNumber, Schedule wantedSchedule);
    }
}
