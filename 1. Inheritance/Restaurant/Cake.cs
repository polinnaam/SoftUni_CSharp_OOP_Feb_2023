using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    public class Cake : Dessert
    {
        private const double grams = 350;
        private const double calories = 1000;
        private const decimal price = 5;
        public Cake(string name) 
            : base(name, 0, 0, 0)
        {

        }
        public virtual double Grams
        {
            get { return grams; }
        }
        public virtual double Calorie
        {
            get { return calories; }
        }
        public virtual decimal Price
        {
            get { return price; }
        }
    }
}
