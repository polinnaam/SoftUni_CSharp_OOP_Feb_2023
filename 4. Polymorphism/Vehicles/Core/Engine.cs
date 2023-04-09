using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicles.Core.Interfaces;
using Vehicles.IO;
using Vehicles.IO.Interfaces;
using Vehicles.Models;
using Vehicles.Models.Interfaces;

namespace Vehicles.Core
{
    public class Engine : IEngine
    {
        private readonly IReader reader;

        private readonly IWriter writer;

        private readonly IVehicle Vehicle;

        private ICollection<IVehicle> vehicles;

        public Engine(IReader reader, IWriter writer, IVehicle vehicle)
        {
            this.reader = reader;
            this.writer = writer;
            this.Vehicle = vehicle;

            vehicles = new List<IVehicle>();
        }

        public void Run(IReader reader, IWriter writer, IVehicle vehicle)
        {
            vehicles.Add(CreateVehicle()); // car
            vehicles.Add(CreateVehicle()); // truck
            vehicles.Add(CreateVehicle()); // bus

            int numOfCommands = int.Parse(reader.ConsoleReadLine());

            for (int i = 0; i < numOfCommands; i++)
            {
                string[] vehicleActions = reader.ConsoleReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string action = vehicleActions[0];
                string currVehicle = vehicleActions[1];
                try 
                {
                    if (action == "Drive")
                    {
                        double kms = double.Parse(vehicleActions[2]);
                        writer.ConsoleWriteLine(vehicles.FirstOrDefault(t => t.GetType().Name == currVehicle).Drive(kms));
                    }
                    else if (action == "Refuel")
                    {
                        double litters = double.Parse(vehicleActions[2]);                       
                        vehicles.FirstOrDefault(t => t.GetType().Name == currVehicle).Refuel(litters);
                    }
                    else if (action == "DriveEmpty" && currVehicle == "Bus")
                    {
                        double kms = double.Parse(vehicleActions[2]);
                        writer.ConsoleWriteLine(vehicles.FirstOrDefault(t => t.GetType().Name == currVehicle).DriveEmpty(kms));
                    }
                }
                catch (ArgumentException ex)
                {
                    writer.ConsoleWriteLine(ex.Message);
                }
                catch(Exception ex)
                {
                    throw;
                }
            }
        }
        public void PrintOutupData(IWriter writer, IVehicle vehicle)
        {
            foreach (Vehicle currVehicle in vehicles)
            {
                writer.ConsoleWriteLine(currVehicle.ToString());
            }
        }

        private IVehicle CreateVehicle()
        {
            string[] input = reader.ConsoleReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string vehicleType = input[0];
            double fuelQuantity = double.Parse(input[1]);
            double fuelConsumption = double.Parse(input[2]);
            double tankCapacity = double.Parse(input[3]);

            if (tankCapacity < fuelQuantity)
            {
                fuelQuantity = 0;
            }

            if (vehicleType == "Car")
            {               
                Vehicle car = new Car(fuelQuantity, fuelConsumption, tankCapacity);
                return car;
            }
            else if (vehicleType == "Truck")
            {
                Vehicle truck = new Truck(fuelQuantity, fuelConsumption, tankCapacity);
                return truck;
            }
            else if (vehicleType == "Bus")
            {
                Vehicle bus = new Bus(fuelQuantity, fuelConsumption, tankCapacity);
                return bus;
            }
            else
            {
                throw new ArgumentException("Invalid vehicle type!");
            }
        }
    }
}
