using System;
using System.Collections.Generic;
using System.IO;
namespace VehicleRent
{
    public class Schedule : IOverlappable
    {
        DateTime pickUp;
        DateTime dropOff;

        public Schedule(string p, string d)
        {
            DateTime pick = Convert.ToDateTime(p);
            DateTime drop = Convert.ToDateTime(d);
            pickUp = pick;
            dropOff = drop;
        }

        public DateTime getPickUp()
        {
            return pickUp;
        }

        public DateTime getDropOff()
        {
            return dropOff;
        }

        public bool Overlaps(Schedule other)
        {
            if (pickUp < other.getPickUp() && dropOff < other.getPickUp())
            {
                return false;
            }
            else if (pickUp > other.getDropOff() && dropOff > other.getDropOff())
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}