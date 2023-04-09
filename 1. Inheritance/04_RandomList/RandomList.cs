﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CustomRandomList
{
    public class RandomList : List<string>
    {
        private Random random;

        public RandomList()
        {
            this.random = new Random();
        }

        public string RandomString() 
        {
            int index = random.Next(0, this.Count);
            string stringToRemove = this[index];
            this.RemoveAt(index);

            return stringToRemove;
        }
    }
}
