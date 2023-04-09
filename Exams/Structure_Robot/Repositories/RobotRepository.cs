using RobotService.Models.Contracts;
using RobotService.Repositories.Contracts;
using Structure_Robot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structure_Robot.Repositories
{
    public class RobotRepository : IRepository<IRobot>
    {
        private List<IRobot> robots;
        public RobotRepository()
        {
            robots = new List<IRobot>();
        }
        public IReadOnlyCollection<IRobot> Models()
        {
            return robots.AsReadOnly();
        }
        public void AddNew(IRobot model)
        {
            robots.Add(model);
        }
        public bool RemoveByName(string typeName)
        {
            if (robots.FirstOrDefault(t => t.GetType().Name == typeName) == null)
            {
                return false;
            }
            else
            {
                IRobot robot = robots.First(t => t.GetType().Name == typeName);
                robots.Remove(robot);
                return true;
            }
        }
        public IRobot FindByStandard(int interfaceStandard)
        {
            return robots.FirstOrDefault(s => s.InterfaceStandards.Contains(interfaceStandard));
        }
       
    }
}
