using RobotService.Models.Contracts;
using RobotService.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structure_Robot.Repositories
{
    public class SupplementRepository : IRepository<ISupplement>
    {
        private List<ISupplement> supplements;

        public SupplementRepository()
        {
            supplements = new List<ISupplement>();
        }

        public IReadOnlyCollection<ISupplement> Models()
        {
            return supplements.AsReadOnly();
        }

        public void AddNew(ISupplement model)
        {
            supplements.Add(model);
        }
        public bool RemoveByName(string typeName)
        {
            if (supplements.FirstOrDefault(t => t.GetType().Name == typeName) == null)
            {
                return false;
            }
            else
            {
                ISupplement supplement = supplements.First(t => t.GetType().Name == typeName);
                supplements.Remove(supplement);
                return true;
            }
        }

        public ISupplement FindByStandard(int interfaceStandard)
        {
            return supplements.FirstOrDefault(s => s.InterfaceStandard == interfaceStandard);
        }      
       
    }
}
