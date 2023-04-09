using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zoo;

namespace Zoo
{
    public class Lizard : Reptile
    {
        public Lizard(string name) 
            : base(name)
        {

        }
        public string Name { get; set; }
    }
}
