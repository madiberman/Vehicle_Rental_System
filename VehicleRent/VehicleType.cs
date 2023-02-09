using System;
using System.Collections.Generic;
using System.IO;
namespace VehicleRent
{
    public class VehicleType
    {
        Type type;

        public VehicleType(Vehicle v)
        {
            type = v.GetType();
        }

        public Type getType()
        {
            return type;
        }

    }
}

