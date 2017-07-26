using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Engine.Src
{
    public class VolatileObject
    {
        [Flags]
        public enum State
        {
            /// <summary>
            /// This VolatileObject is in no state
            /// </summary>
            None = 0,
            /// <summary>
            /// This VolatileObject is currently locked
            /// </summary>
            Locked = 1,
            /// <summary>
            /// This VolatileObject is being accessed
            /// </summary>
            Accessed = 2,
            /// <summary>
            /// This VolatileObject is currently affected by Unity
            /// </summary>
            Unity = 4,
            /// <summary>
            /// This VolatileObject is currently affected by the threaded environment
            /// </summary>
            Threaded = 8,
            /// <summary>
            /// This VolatileObject is currently having properties changed
            /// </summary>
            Changing = 16
        };
        public State state;

        private List<Request> requests;

        public int RequestCount { get { lock (requests) { return requests.Count; } } }

        public void Request(Request request)
        {
            lock(requests)
            {
                requests.Add(request);
            }
        }

        public Request Pop()
        {
            lock(requests)
            {
                Request temp = requests[0];
                requests.RemoveAt(0);
                return temp;
            }
        }

        public void Clear()
        {
            lock(requests)
            {
                requests.Clear();
            }
        }

        public bool IsDead { get; private set; }

        public void Kill()
        {
            IsDead = true;
        }
    }
}
