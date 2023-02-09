using System;
namespace VehicleRent
{
    public class Cars : Vehicle
    {
        string type = "Car";

        public Cars(string make, string model, string registration) : base(make, model, registration)
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
