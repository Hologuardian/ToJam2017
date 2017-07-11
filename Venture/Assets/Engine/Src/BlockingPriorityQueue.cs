using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using Priority_Queue;

namespace Assets.Engine.Src
{
    public class BlockingPriorityQueue<T> where T : StablePriorityQueueNode
    {
        public static int MaxItems = 65536;
        StablePriorityQueue<T> queue = new StablePriorityQueue<T>(MaxItems);
        Object LockObject;
        public void Add(T task)
        {
            lock (LockObject)
            {
                queue.Enqueue(task, task.Priority);
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
}