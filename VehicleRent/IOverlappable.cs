using System;
namespace VehicleRent
{
    interface IOverlappable
    {
        public bool Overlaps(Schedule other);
    }
}
