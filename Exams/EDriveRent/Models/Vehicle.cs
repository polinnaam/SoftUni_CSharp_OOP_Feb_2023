using EDriveRent.Models.Contracts;
using EDriveRent.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDriveRent.Models
{
    public abstract class Vehicle : IVehicle
    {
        public Vehicle(string brand, string model, double maxMileage, string licensePlateNumber)
        {
            Brand = brand;
            Model = model;
            MaxMileage = maxMileage;
            LicensePlateNumber = licensePlateNumber;

            BatteryLevel = 100;
            IsDamaged = false;
        }

        private string brand;
        public string Brand
        {
            get => brand;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.BrandNull));
                }
                brand = value;
            }
        }
        private string model;
        public string Model
        {
            get => model;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.ModelNull));
                }
                model = value;
            }
        }
        private double maxMileage;

        public double MaxMileage
        {
            get { return maxMileage; }
            private set { maxMileage = value; }
        }

        private string licensePlateNumber;
        public string LicensePlateNumber
        {
            get => licensePlateNumber;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.LicenceNumberRequired));
                }
                licensePlateNumber = value;
            }
        }
        private int batteryLevel;
        public int BatteryLevel
        {
            get { return batteryLevel; }
            private set { batteryLevel = value; }
        }
        private bool isDamaged;
        public bool IsDamaged
        {
            get { return isDamaged; }
            private set { isDamaged = value; }
        }

        public void ChangeStatus()
        {
            if (IsDamaged)
            {
                IsDamaged = false;
            }
            else if (!IsDamaged)
            {
                IsDamaged = true;
            }
        }

        public void Drive(double mileage)
        {
            //change battery level
            int passedMaxMileage = (int)Math.Round((mileage/ this.MaxMileage) * 100);
            this.BatteryLevel -= passedMaxMileage;
            if (MaxMileage == 180)
            {
                BatteryLevel -= 5;
            }
        }

        public void Recharge()
        {
            this.BatteryLevel = 100;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
           
            sb.Append($"{this.Brand} {this.Model} License plate: {LicensePlateNumber} Battery: {BatteryLevel}% Status: ");
            if (IsDamaged)
            {
                sb.Append("damaged");
            }
            else
            {
                sb.Append("OK");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
