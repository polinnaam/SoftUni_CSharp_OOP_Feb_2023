using EDriveRent.Models.Contracts;
using EDriveRent.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EDriveRent.Models
{
    public class User : IUser
    {
        public User(string firstName, string lastName, string drivingLicenceNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            DrivingLicenseNumber = drivingLicenceNumber;

            Rating = 0;
            IsBlocked = false;
        }
        private string firstName;
        public string FirstName
        {
            get => firstName;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.FirstNameNull));
                }
                firstName = value;
            }
        }
        private string lastName;
        public string LastName
        {
            get => lastName;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.LastNameNull));
                }
                lastName = value;
            }
        }
        private double rating;
        public double Rating
        {
            get => rating;
            private set
            {
                rating = value;
            }
        }

        private string drivingLicenseNumber;
        public string DrivingLicenseNumber
        {
            get => drivingLicenseNumber;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.DrivingLicenseRequired));
                }
                drivingLicenseNumber = value;
            }
        }
        private bool isBlocked;
        public bool IsBlocked
        {
            get { return isBlocked; }
            private set
            {
                isBlocked = value;
            }
        }

        public void DecreaseRating()
        {
            this.Rating -= 2;
            if (this.Rating < 0)
            {
                this.Rating = 0;
                IsBlocked = true;
            }
        }

        public void IncreaseRating()
        {
            this.Rating += 0.5;
            if (this.Rating > 10)
            {
                this.Rating = 10;
            }
        }

        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName} Driving license: {this.DrivingLicenseNumber} Rating: {this.Rating}";
        }
    }
}
