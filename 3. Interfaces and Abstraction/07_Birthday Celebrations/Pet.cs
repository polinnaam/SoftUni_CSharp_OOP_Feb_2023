using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthdayCelebrations
{
    public class Pet : IIdentify
    {
        public Pet (string name, string birthDate)
        {
            Name = name;
            BirthDate = birthDate;
        }

        public string Name { get; private set; }

        public string BirthDate { get; private set; }
    }
}
