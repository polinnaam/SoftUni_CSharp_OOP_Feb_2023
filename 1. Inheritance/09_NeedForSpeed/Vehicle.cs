﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeedForSpeed
{
    public class Vehicle
    {
        private const double DefaultFuelConsumption = 1.25;
        public Vehicle(int horsePower, double fuel)
        {
            this.HorsePower = horsePower;
            this.Fuel = fuel;
        }

        public virtual double FuelConsumption => DefaultFuelConsumption;
        public double Fuel { get; set; }
        public int HorsePower { get; set; }

        public virtual void Drive (double kilometers)
        {
            Fuel -= kilometers * FuelConsumption;
        }
    }

}