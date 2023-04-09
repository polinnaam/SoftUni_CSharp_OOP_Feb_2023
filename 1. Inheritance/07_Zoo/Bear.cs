using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zoo;

namespace Zoo
{
    public class Bear : Mammal
    {
        public Bear(string name) : base(name)
        {

        }
        public string Name { get; set; }
    }
}
