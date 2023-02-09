using System;
using System.Collections.Generic;
using System.IO;
namespace VehicleRent
{
    class Program
    {
        static void Main(string[] args)
        {
            WestminsterRentalVehicle rent = new WestminsterRentalVehicle();

            while (true)
            {
                rent.CustomerMenu(rent);
            }
        }
    }
}