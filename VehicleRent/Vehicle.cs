using System;
using System.Collections.Generic;
using System.IO;
namespace VehicleRent
{
    public class Vehicle : IComparable<Vehicle>
    {
        string make;
        string model;
        string registration;
        List<Schedule> vehicleSchedule = new List<Schedule>();

        public Vehicle(string mak, string mod, string reg)
        {
            make = mak;
            model = mod;
            registration = reg;
        }
        public string getModel()
        {
            return model;
        }
        public void setModel(string setMod)
        {
            model = setMod;
        }
        public string getMake()
        {
            return make;
        }
        public void setMake(string setMak)
        {
            make = setMak;
        }
        public string getRegistration()
        {
            return registration;
        }
        public void setRegistration(string setReg)
        {
            registration = setReg;
        }
        public virtual void display()
        {
            Console.WriteLine("Make: " + make);
            Console.WriteLine("Model: " + model);
            Console.WriteLine("Registration: " + registration);
        }

        public int CompareTo(Vehicle other)
        {
            return make.CompareTo(other.getMake());
        }

        public void WriteToFile(StreamWriter sw)
        {
            sw.WriteLine($"{model},{make},{registration}");
        }

        public void setSchedule(Schedule s)
        {
            if (s.getDropOff() < s.getPickUp())
            {
                Console.WriteLine("Dropoff date cannot be before Pickup date.");
            }
            else if (vehicleSchedule.Count == 0)
            {
                vehicleSchedule.Add(s);
                Console.WriteLine("Schedule has been successfully added.");
            }
            else
            {
                foreach (Schedule sched in vehicleSchedule)
                {
                    if (sched.Overlaps(s))
                    {
                        Console.WriteLine("Schedule overlaps with existing schedule");
                        break;
                    }
                    else
                    {
                        vehicleSchedule.Add(s);
                        Console.WriteLine("Schedule has been successfully added.");
                        break;
                    }
                }
            }

        }

        public List<Schedule> getSchedule()
        {
            return vehicleSchedule;
        }

        public void printSchedule()
        {
            for(int i = 0; i<vehicleSchedule.Count; i++)
            {
                Console.WriteLine("Pickup: " + vehicleSchedule[i].getPickUp().ToString("dd-MM-yyyy"));
                Console.WriteLine("Dropoff: " + vehicleSchedule[i].getDropOff().ToString("dd-MM-yyyy"));
            }
        }

        public virtual string getType()
        {
                string noType = "Type does not exist";
                return noType;
        }

    }
}
