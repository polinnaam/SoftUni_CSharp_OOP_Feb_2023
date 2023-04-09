using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles.IO.Interfaces
{
    public interface IWriter
    {
        public void ConsoleWriteLine(string message);
    }
}
