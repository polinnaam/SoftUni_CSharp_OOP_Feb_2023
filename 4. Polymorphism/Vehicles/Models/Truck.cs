using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicles.Models.Interfaces;

namespace Vehicles.Models
{
    public class Truck : Vehicle, IVehicle
    {
        private const double IncreasedNum = 1.6;
        public Truck(double fuelQuantity, double fuelConsumptionPerKm, double tankCapacity) 
            : base(fuelQuantity, fuelConsumptionPerKm, tankCapacity, IncreasedNum)
        {
        }

        public override void Refuel(double litters)
        {
            if (litters + this.FuelQuantity > this.TankCapacity)
            {
                throw new ArgumentException($"Cannot fit {litters} fuel in the tank");
            }

            base.Refuel(litters * 0.95);
        }
    }
}
