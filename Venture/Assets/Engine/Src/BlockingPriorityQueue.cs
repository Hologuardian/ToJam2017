using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using Priority_Queue;

public class BlockingPriorityQueue<T> where T : FastPriorityQueueNode
{
    public static int MaxItems = 65536;
    FastPriorityQueue<T> queue = new FastPriorityQueue<T>(MaxItems);
    Object LockObject;
    public void Add(T task, float priority)
    {
        lock(LockObject)
        {
            queue.Enqueue(task, priority);
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
