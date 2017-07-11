using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Priority_Queue;

public delegate void Task();
public class TaskNode : FastPriorityQueueNode
{
    public TaskNode(Task task)
    {
        this.task = task;
    }
    public Task task;
}