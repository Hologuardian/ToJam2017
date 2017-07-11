using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Priority_Queue;
namespace Assets.Engine.Src
{
    public delegate void Task();

    public class TaskNode : StablePriorityQueueNode
    {
        public TaskNode()
        {

        }

        public TaskNode(Task task, string name)
        {
            this.task = task;
            this.name = name;
        }

        public string name;
        public Task task;
    }
}