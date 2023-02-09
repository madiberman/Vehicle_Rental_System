using System;
namespace VehicleRent
{
    public class Motorbikes : Vehicle
    {
        string type = "Motorbike";

        public Motorbikes(string make, string model, string registration) : base(make, model, registration)
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
