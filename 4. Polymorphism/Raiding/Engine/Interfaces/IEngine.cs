using Raiding.IO.Interfaces;
using Raiding.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raiding.Engine.Interfaces
{
    public interface IEngine 
    {
        public IBaseHero CreateHero(string heroName, string heroType, IWriter consoleWriter);
    }
}
