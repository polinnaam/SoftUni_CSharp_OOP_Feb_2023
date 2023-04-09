using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BorderControl
{
    public class Robots : IIdentify
    {
        public Robots (string name, string id)
        {
            Name = name;
            Id = id;
        }
        public string Name { get; private set; }

        public string Id { get; private set; }
    }
}
