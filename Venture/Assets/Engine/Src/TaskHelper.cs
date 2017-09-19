using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Engine
{
    public enum TaskPriority
    {
        Highest = 0,
        High = 1,
        Medium = 2,
        Low = 4,
        Lowest = 16
    };

    public class TaskHelper
    {
        public static TaskManager TaskManager;
        
    }
}
