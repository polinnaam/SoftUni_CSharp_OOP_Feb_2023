using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonsInfo
{
    public class Person
    {
        private string firstName;
        private string lastName;
        private int age;
        private decimal salary;

        public Person (string firstName, string lastName, int age, decimal salary)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;
            this.salary = salary;
        }

        //public string FirstName 
        //{
        //    get { return firstName; }
        //    private set 
        //    { 
        //        if (value.Length > 3)
        //        {
        //            firstName = value; 
        //        }
        //        else
        //        {
        //            throw new ArgumentException("First name cannot contain fewer than 3 symbols!");
        //        }                
        //    }
        //}
        //public string LastName
        //{
        //    get { return lastName; }
        //    private set 
        //    { 
        //        if (value.Length > 3)
        //        {
        //            lastName = value;
        //        }
        //        else
        //        {
        //            throw new ArgumentException("Last name cannot contain fewer than 3 symbols!");
        //        }
        //    }
        //}
        public int Age
        {
            get { return this.age; }
            //private set 
            //{ 
            //    if (value > 0)
            //    {
            //        age = value;
            //    }
            //    else
            //    {
            //        throw new ArgumentException("Age cannot be zero or a negative integer!");
            //    }
            //}
        }
        //public decimal Salary
        //{
        //    get { return salary; }
        //    private set 
        //    {
        //        if (value > 650)
        //        {
        //            salary = value;
        //        }
        //        else
        //        {
        //            throw new ArgumentException("Salary cannot be less than 650 leva!");
        //        }
        //    }
        //}
        //public override string ToString()
        //{
        //    return $"{this.firstName} {this.lastName} receives {this.salary:f2} leva.";
        //}

        //public decimal IncreaseSalary(decimal percentage)
        //{
        //    decimal increase = this.salary * percentage / 100m;
        //    if (this.age < 30)
        //    {
        //        increase /= 2;
        //    }
        //    return this.salary += increase;
        //}
    }
}
