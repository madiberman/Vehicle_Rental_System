using System;
namespace VehicleRent
{
    public class ElectricCars : Vehicle
    {
        string type = "Electric Car";

        public ElectricCars(string make, string model, string registration) : base(make, model, registration)
        {
        }

        public override string getType()
        {
            return type;
        }

        public override void display()
        {
            base.display();
            Console.WriteLine("Type: " + $"{type}");
            Console.WriteLine("");
        }
    }
}
