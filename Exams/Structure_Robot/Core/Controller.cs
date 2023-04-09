using RobotService.Core.Contracts;
using RobotService.Models.Contracts;
using RobotService.Utilities.Messages;
using Structure_Robot.Models;
using Structure_Robot.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structure_Robot.Core
{
    public class Controller : IController
    {
        private RobotRepository robotRepository;
        private SupplementRepository supplementRepository;

        public Controller()
        {
            robotRepository = new RobotRepository();
            supplementRepository = new SupplementRepository();
        }

        public string CreateRobot(string model, string typeName)
        {
            if (typeName != "DomesticAssistant" && typeName != "IndustrialAssistant")
            {
                return string.Format(OutputMessages.RobotCannotBeCreated, typeName);
            }

            IRobot robot = null;

            if (typeName == "DomesticAssistant")
            {
                robot = new DomesticAssistant(model);
            }
            if (typeName == "IndustrialAssistant")
            {
                robot = new IndustrialAssistant(model);
            }
            robotRepository.AddNew(robot);

            return string.Format(OutputMessages.RobotCreatedSuccessfully, typeName, model);
        }

        public string CreateSupplement(string typeName)
        {
            if (typeName != "SpecializedArm" && typeName != "LaserRadar")
            {
                return string.Format(OutputMessages.SupplementCannotBeCreated, typeName);
            }

            ISupplement supplement = null;

            if (typeName == "SpecializedArm")
            {
                supplement = new SpecializedArm();
            }
            if (typeName == "LaserRadar")
            {
                supplement = new LaserRadar();
            }
            supplementRepository.AddNew(supplement);

            return string.Format(OutputMessages.SupplementCreatedSuccessfully, typeName);
        }
        public string UpgradeRobot(string model, string supplementTypeName)
        {
            ISupplement supplement = supplementRepository
                .Models()
                .First(s => s.GetType().Name == supplementTypeName);

            int interfaceValueOfSupplement = supplement.InterfaceStandard;

            List<IRobot> robots = robotRepository
                .Models()
                .ToList();

            List<IRobot> newRobots = new List<IRobot>();

            foreach (var robot in robots)
            {
                if (!robot.InterfaceStandards.Any())
                {
                    newRobots.Add(robot);
                }
                else if (!robot.InterfaceStandards.Contains(interfaceValueOfSupplement))
                {
                    newRobots.Add(robot);
                }
            }
            newRobots = newRobots.Where(n => n.Model == model).ToList();

            if (newRobots.Count == 0)
            {
                //empty
                return string.Format(OutputMessages.AllModelsUpgraded, model);
            }
            else
            {
                newRobots.First().InstallSupplement(supplement);
                supplementRepository.RemoveByName(supplementTypeName);

                return string.Format(OutputMessages.UpgradeSuccessful, model, supplementTypeName);
            }
        }

        public string PerformService(string serviceName, int intefaceStandard, int totalPowerNeeded)
        {
            List<IRobot> robotsList = robotRepository.Models().ToList();

            foreach (var robot in robotRepository.Models())
            {
                if (!robot.InterfaceStandards.Contains(intefaceStandard))
                {
                    robotsList.Remove(robot);
                }
            }
            if (robotsList.Count == 0)
            {
                //not support
                return string.Format(OutputMessages.UnableToPerform, intefaceStandard);
            }

            robotsList = robotsList
                .OrderByDescending(b => b.BatteryLevel)
                .ToList();

            int sumOfBatteryLevel = 0;
            foreach (var robot in robotsList)
            {
                sumOfBatteryLevel += robot.BatteryLevel;
            }

            if (sumOfBatteryLevel < totalPowerNeeded)
            {
                return string.Format(OutputMessages.MorePowerNeeded, serviceName, (totalPowerNeeded - sumOfBatteryLevel));
            }

            int countOfRobots = 0;

            while (totalPowerNeeded > 0)
            {
                foreach (var robot in robotsList)
                {
                    if (robot.BatteryLevel >= totalPowerNeeded)
                    {
                        robot.ExecuteService(totalPowerNeeded);
                        countOfRobots++;
                        totalPowerNeeded -= robot.BatteryLevel;
                        break;
                    }
                    else if (robot.BatteryLevel < totalPowerNeeded)
                    {
                        totalPowerNeeded -= robot.BatteryLevel;
                        robot.ExecuteService(robot.BatteryLevel);
                        totalPowerNeeded -= robot.BatteryLevel;
                        countOfRobots++;
                    }
                }
            }
            return string.Format(OutputMessages.PerformedSuccessfully, serviceName, countOfRobots);
        }
        public string RobotRecovery(string model, int minutes)
        {
            List<IRobot> robotsList = robotRepository
                .Models()
                .Where(m => m.Model == model)
                .Where(r => r.BatteryLevel < r.BatteryCapacity / 2)
                .ToList();

            int fedCount = 0;
            foreach (var robot in robotsList)
            {
                robot.Eating(minutes);
                fedCount++;
               
            }
            return string.Format(OutputMessages.RobotsFed, fedCount);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            List<IRobot> robots = robotRepository
                .Models()
                .OrderByDescending(b => b.BatteryLevel)
                .ThenBy(b => b.BatteryCapacity)
                .ToList();

            foreach(var robot in robots)
            {
                sb.AppendLine(robot.ToString());
            }
            return sb.ToString().TrimEnd();
        }             
    }
}
