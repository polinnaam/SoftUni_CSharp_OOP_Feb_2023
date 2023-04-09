﻿using RobotService.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structure_Robot.Models
{
    public abstract class Supplement : ISupplement
    {
        private int interfaceStandard;
        private int batteryUsage;
        public Supplement(int interfaceStandard, int batteryUsage)
        {
            InterfaceStandard = interfaceStandard;
            BatteryUsage = batteryUsage;
        }

        public int InterfaceStandard
        { get { return interfaceStandard; }
            private set
            {
                interfaceStandard = value;
            }
        }

        public int BatteryUsage
        {
            get { return batteryUsage; }
            private set
            {
                batteryUsage = value;
            }
        }
    }
}
