using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicles.Models.Interfaces;

namespace Vehicles.Models
{
    public abstract class Vehicle : IVehicle
    {
        private double IncreasedNum;
        
        protected Vehicle(double fuelQuantity, double fuelConsumptionPerKm, double tankCapacity, double IncreasedNum)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumptionPerKm = fuelConsumptionPerKm;
            this.IncreasedNum = IncreasedNum;
            TankCapacity = tankCapacity;
        }

        public double FuelQuantity { get; private set; }
        public double FuelConsumptionPerKm { get; private set; }
        public double TankCapacity { get; private set; }

        public string Drive(double distance)
        {
            double increasedLitters = distance * (FuelConsumptionPerKm + IncreasedNum);
            return DriveWithOrWithoutPeople(distance, increasedLitters);

        }
        public string DriveEmpty(double distance)
        {
            double increasedLitters = distance * FuelConsumptionPerKm;
            return DriveWithOrWithoutPeople(distance, increasedLitters);
        }

        private string DriveWithOrWithoutPeople(double distance, double increasedLitters)
        {
            if (increasedLitters > FuelQuantity)
            {
                throw new ArgumentException($"{this.GetType().Name} needs refueling");
            }

            FuelQuantity -= increasedLitters;
            return $"{this.GetType().Name} travelled {distance} km";
        }

        public virtual void Refuel(double litters)
        {
            if (litters <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }
            double availableSpace = TankCapacity - FuelQuantity;
            if (litters > availableSpace)
            {
                throw new ArgumentException($"Cannot fit {litters} fuel in the tank");
            }
            this.FuelQuantity += litters;
        }
        public override string ToString()
        {
            return $"{this.GetType().Name}: {FuelQuantity:f2}";
        }
    }
}
