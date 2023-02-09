using System;
namespace VehicleRent
{
    public class Vans : Vehicle
    {
        string type = "Van";

        public Vans(string make, string model, string registration) : base(make, model, registration)
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
