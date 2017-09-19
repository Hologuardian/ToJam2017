using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using Priority_Queue;

namespace Assets.Engine
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

        /// <summary>
        /// Unlikely to be thread safe, will return null if object is missing.
        /// </summary>
        /// <returns></returns>
        public T CheckPop()
        {
            if (queue.Count > 0)
            {
                lock (LockObject)
                {
                    return queue.Dequeue();
                }
            }
            return null;
        }

        /// <summary>
        /// Thread safe, will block if queue is empty.
        /// </summary>
        /// <returns></returns>
        public T Pop()
        {
            while (queue.Count <= 0) ;
            lock (LockObject)
            {
                return queue.Dequeue();
            }
        }
    }
}