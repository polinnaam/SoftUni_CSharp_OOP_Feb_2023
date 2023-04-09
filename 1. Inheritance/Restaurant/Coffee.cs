using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    public class Coffee : HotBeverage
    {
        private double coffeeMilliliters = 50;
        private decimal coffeePrice = 3.5m;
        private double caffeine;
        public Coffee(string name, decimal price, double milliliters, double caffeine) 
            : base(name, 0, 0)
        {
            Caffeine = caffeine;

        }
        public virtual double CoffeeMilliliters
        {
            get { return coffeeMilliliters; }
        }
        public virtual decimal CoffeePrice
        {
            get { return coffeePrice; }
        }
        public virtual double Caffeine
        {
            get { return caffeine; }
            set { caffeine = value; }
        }
        
    }
}
