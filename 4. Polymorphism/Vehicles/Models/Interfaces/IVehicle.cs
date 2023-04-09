using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles.Models.Interfaces
{
    public interface IVehicle
    {        
        public double FuelQuantity { get; }
        public double FuelConsumptionPerKm { get; }
        public double TankCapacity { get; }
        public string Drive(double distance);
        public void Refuel(double litters);
        public string DriveEmpty(double distance);
    }
}
