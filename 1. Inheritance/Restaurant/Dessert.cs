﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    public class Dessert : Food
    {
        private double calories;
        public Dessert(string name, decimal price, double grams, double calories) 
            : base(name, price, grams)
        {
            Calories = calories;
        }
        public virtual double Calories
        {
            get { return calories; }
            set { calories = value; }
        }
    }
}
