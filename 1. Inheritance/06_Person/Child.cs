﻿using Person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person
{
    internal class Child : Person
    {
        private string name;
        private int age;

        public Child(string name, int age) 
            : base(name, age)
        {

        }
        public string Name { get; set; }
        public override int Age { 
            get
            {
                return base.Age;
            }
            set
            {
                if (value <= 15)
                {
                    base.Age = value;   
                }
            }
        }
    }
}
