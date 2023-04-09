using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicles.IO;
using Vehicles.IO.Interfaces;
using Vehicles.Models;
using Vehicles.Models.Interfaces;

namespace Vehicles.Core.Interfaces
{
    public interface IEngine
    {
        public void Run(IReader reader, IWriter writer, IVehicle vehicle);
        public void PrintOutupData(IWriter writer, IVehicle vehicle);
    }
}
