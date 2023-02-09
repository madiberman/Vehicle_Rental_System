using System;
using System.Collections.Generic;
using System.IO;
namespace VehicleRent
{
    public class WestminsterRentalVehicle : IRentalVehicleCustomer, IRentalVehicleManager
    {
        List<Vehicle> parkingSpots = new List<Vehicle>();

        public void listAvailableVehicles(Schedule wantedSchedule, VehicleType type)
        {
            List<Vehicle> availType = new List<Vehicle>();
            List<Vehicle> availTypeAndSched = new List<Vehicle>();
            foreach (Vehicle v in parkingSpots)
            {
                if (v.GetType() == type.getType())
                {
                    availType.Add(v);
                }
            }

            foreach (Vehicle vehType in availType)
            {
                if (vehType.getSchedule().Count == 0)
                {
                    availTypeAndSched.Add(vehType);
                }
                else
                {
                    for (int i = 0; i < vehType.getSchedule().Count; i++)
                    {
                        Console.WriteLine(vehType.getSchedule().Count);
                        if (!vehType.getSchedule()[i].Overlaps(wantedSchedule))
                        {
                            availTypeAndSched.Add(vehType);
                            Console.WriteLine("Available types and schedule: " + availTypeAndSched.Count);
                        }
                    }
                }
            }
            Console.WriteLine("Vehicles with the requested type and available schedule: ");
            Console.WriteLine("");
            foreach (Vehicle veh in availTypeAndSched)
            {
                veh.display();
            }

        }

        public bool rentVehicle(string RegistrationNumber, Schedule wantedSchedule)
        {
            foreach (Vehicle veh in parkingSpots)
            {
                if (veh.getRegistration() == RegistrationNumber)
                {
                    veh.setSchedule(wantedSchedule);
                    return true;
                }
                else
                {
                    Console.WriteLine("Registration number doesn't match existing vehicle in parkning lot.");
                    return false;
                }
            }
            return false;
        }

        public bool addVehicle(Vehicle v)
        {
            if (parkingSpots.Count < 50 && !parkingSpots.Contains(v))
            {

                parkingSpots.Add(v);
                Console.WriteLine("Vehicle Successfully added.");
                Console.WriteLine("Remaining available parking spots: " + (50 - parkingSpots.Count));
                return true;
            }
            else
            {
                if (parkingSpots.Contains(v))
                {
                    Console.WriteLine("This vehicle has already been added.");
                }
                else if (parkingSpots.Count == 50)
                {
                    Console.WriteLine("The parking spots are all full, a new vehicle cannot be added.");
                }
                else
                {
                    Console.WriteLine("Incorrect information input");
                }
                return false;
            }
        }

        public bool deleteVehicle(string reg)
        {
            int j = 0;
            for (int i = 0; i < parkingSpots.Count; i++)
            {
                if (parkingSpots[i].getRegistration().Equals(reg))
                {
                    parkingSpots.Remove(parkingSpots[i]);
                    Console.WriteLine("Vehicle deleted");
                    j++;
                }
            }
            if (j == 1)
            {
                return true;
            }
            else
            {
                Console.WriteLine("Vehicle does not exist to be deleted.");
                return false;
            }
        }

        public void listVehicles()
        {
            for (int i = 0; i < parkingSpots.Count; i++)
            {
                Console.WriteLine("Vehicle registration number: " + parkingSpots[i].getRegistration());
                Console.WriteLine("Vehicle type: " + parkingSpots[i].getType());
                parkingSpots[i].printSchedule();
                Console.WriteLine("");
            }
        }

        public void listVehiclesOrdered()
        {
            parkingSpots.Sort();
            for (int i = 0; i < parkingSpots.Count; i++)
            {
                Console.WriteLine("");
                Console.WriteLine("Vehicle registration number: " + parkingSpots[i].getRegistration());
                Console.WriteLine("Vehicle type: " + parkingSpots[i].getType());
                Console.WriteLine("");
                parkingSpots[i].printSchedule();
            }
        }

        public void generateReport(string fileName)
        {
            StreamWriter sw = new StreamWriter($"{fileName}");
            foreach (Vehicle v in parkingSpots)
            {
                v.display();
                Console.WriteLine();
                v.WriteToFile(sw);
            }
            sw.Dispose();
        }

        public void CustomerMenu(WestminsterRentalVehicle rent)
        {
            //Console.Clear();
            Console.WriteLine("Customer Menu");
            Console.WriteLine("");
            Console.WriteLine("Options:");
            Console.WriteLine("");
            Console.WriteLine("To list available vehicles:");
            Console.WriteLine("Enter 'ListAvail'");
            Console.WriteLine("");
            Console.WriteLine("To rent a vehicle:");
            Console.WriteLine("Enter 'Rent'");
            Console.WriteLine("");
            Console.WriteLine("To switch to Admin Menu:");
            Console.WriteLine("Enter 'Admin'");
            Console.WriteLine("");
            string answer = Console.ReadLine();

            if (answer == "ListAvail")
            {
                rent.customerList(rent);
            }
            else if (answer == "Rent")
            {
                rent.customerRent(rent);
            }
            else if (answer == "Admin")
            {
                rent.AdminMenu(rent);
            }
        }

        public void customerList(WestminsterRentalVehicle rent)
        {
            Console.Clear();
            Console.WriteLine("Please enter your desired pickup date: ");
            Console.WriteLine("");
            string p0 = Console.ReadLine();

            Console.WriteLine("Please enter your desired dropoff date: ");
            Console.WriteLine("");
            string d0 = Console.ReadLine();

            Schedule sched0 = new Schedule(p0, d0);
            Console.WriteLine("");
            Console.WriteLine("Please enter your desired vehicle type (Car, Van, Motorbike, ElectricCar): ");
            string type0 = Console.ReadLine();
            if (type0 == "Car")
            {
                Cars vehEx = new Cars("example", "example", "example");
                VehicleType typeEx = new VehicleType(vehEx);
                rent.listAvailableVehicles(sched0, typeEx);
            }
            else if (type0 == "Van")
            {
                Vans vehEx = new Vans("example", "example", "example");
                VehicleType typeEx = new VehicleType(vehEx);
                rent.listAvailableVehicles(sched0, typeEx);
            }
            else if (type0 == "Motorbike")
            {
                Motorbikes vehEx = new Motorbikes("example", "example", "example");
                VehicleType typeEx = new VehicleType(vehEx);
                rent.listAvailableVehicles(sched0, typeEx);
            }
            else if (type0 == "ElectricCar")
            {
                ElectricCars vehEx = new ElectricCars("example", "example", "example");
                VehicleType typeEx = new VehicleType(vehEx);
                rent.listAvailableVehicles(sched0, typeEx);
            }
        }

        public void customerRent(WestminsterRentalVehicle rent)
        {
            Console.Clear();
            Console.WriteLine("Please enter the registration number of your desired vehicle: ");
            Console.WriteLine("");
            string r1 = Console.ReadLine();

            Console.WriteLine("Please enter your desired pickup date: ");
            Console.WriteLine("");
            string p1 = Console.ReadLine();

            Console.WriteLine("Please enter your desired dropoff date: ");
            Console.WriteLine("");
            string d1 = Console.ReadLine();

            Schedule sched1 = new Schedule(p1, d1);
            rent.rentVehicle(r1, sched1);
        }

        public void AdminMenu(WestminsterRentalVehicle rent)
        {
            Console.Clear();
            Console.WriteLine("Admin Menu");
            Console.WriteLine("");
            Console.WriteLine("Options:");
            Console.WriteLine("");
            Console.WriteLine("To add a vehicle to the system:");
            Console.WriteLine("Enter 'Add'");
            Console.WriteLine("");
            Console.WriteLine("To delete a vehicle from the system:");
            Console.WriteLine("Enter 'Delete'");
            Console.WriteLine("");
            Console.WriteLine("To list vehicles in the system");
            Console.WriteLine("Enter 'List'");
            Console.WriteLine("");
            Console.WriteLine("To list vehicles alphabetically by make");
            Console.WriteLine("Enter 'ListOrder'");
            Console.WriteLine("");
            Console.WriteLine("To generate a report in a .txt file:");
            Console.WriteLine("Enter 'Report'");
            Console.WriteLine("");
            Console.WriteLine("To return to Customer Menu: ");
            Console.WriteLine("Enter 'Customer'");
            Console.WriteLine("");
            string answer2 = Console.ReadLine();
            if (answer2 == "Add")
            {
                rent.managerAdd(rent);
            }
            else if (answer2 == "Delete")
            {
                rent.managerDelete(rent);
            }
            else if (answer2 == "List")
            {
                rent.managerList(rent);
            }
            else if (answer2 == "ListOrder")
            {
                rent.managerListOrder(rent);
            }
            else if (answer2 == "Report")
            {
                rent.managerReport(rent);
            }
            else if (answer2 == "Customer")
            {
                rent.CustomerMenu(rent);
            }
        }

        public void managerAdd(WestminsterRentalVehicle rent)
        {
            Console.Clear();
            Console.WriteLine("Enter make: ");
            Console.WriteLine("");
            string makeA = Console.ReadLine();
            Console.WriteLine("");
            Console.WriteLine("Enter model: ");
            Console.WriteLine("");
            string modelA = Console.ReadLine();
            Console.WriteLine("");
            Console.WriteLine("Enter registration number: ");
            Console.WriteLine("");
            string regA = Console.ReadLine();
            Console.WriteLine("");
            Console.WriteLine("Enter type (Car, Van, Motorbike, ElectricCar, None): ");
            Console.WriteLine("");
            string typeA = Console.ReadLine();

            switch (typeA)
            {
                case "None":
                    Vehicle vehA = new Vehicle(makeA, modelA, regA);
                    rent.addVehicle(vehA);
                    break;

                case "Car":
                    Cars carA = new Cars(makeA, modelA, regA);
                    rent.addVehicle(carA);
                    break;
                case "Van":
                    Vans vanA = new Vans(makeA, modelA, regA);
                    rent.addVehicle(vanA);
                    break;

                case "Motorbike":
                    Motorbikes motA = new Motorbikes(makeA, modelA, regA);
                    rent.addVehicle(motA);
                    break;

                case "ElectricCar":
                    ElectricCars evA = new ElectricCars(makeA, modelA, regA);
                    rent.addVehicle(evA);
                    break;
            }
        }

        public void managerDelete(WestminsterRentalVehicle rent)
        {
            Console.Clear();
            Console.WriteLine("Enter registration number: ");
            Console.WriteLine("");
            string regD = Console.ReadLine();
            rent.deleteVehicle(regD);
        }

        public void managerList(WestminsterRentalVehicle rent)
        {
            //Console.Clear();
            Console.WriteLine("List of vehicles currently in the system: ");
            Console.WriteLine("");
            rent.listVehicles();
            Console.WriteLine("");
        }

        public void managerListOrder(WestminsterRentalVehicle rent)
        {
            Console.Clear();
            rent.listVehiclesOrdered();
        }

        public void managerReport(WestminsterRentalVehicle rent)
        {
            Console.Clear();
            Console.WriteLine("Enter desired filename: ");
            Console.WriteLine("");
            string nameR = Console.ReadLine();
            rent.generateReport(nameR);
        }
    }
}

