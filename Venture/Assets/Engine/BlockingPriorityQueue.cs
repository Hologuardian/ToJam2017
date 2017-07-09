using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

public class BlockingPriorityQueue<T>
{
    Queue<T> queue = new Queue<T>();
    Object LockObject;
    public void Add(T task, int priority, int timeRequested)
    {
        lock(LockObject)
        {
            queue.Enqueue(task);
        }
    }

    public T Pop()
    {
        while (queue.Count <= 0) ;
        lock (LockObject)
        {
            //TODO Heuristic for accepting tasks
            return queue.Dequeue();
        }
    }
}
