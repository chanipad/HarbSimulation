﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary.HarborFramwork.DockingInfo;

namespace ClassLibrary.HarborFramwork.ContainerYardInfo
{
    public class ContainerHistory
    {
        public List<Location> location { get; set; }
        public int getContainerHistory(int containerId)
        { 
            return location.Count;
        }
    }
}
