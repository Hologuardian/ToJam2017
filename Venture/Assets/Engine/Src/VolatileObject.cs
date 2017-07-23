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
            Threaded = 8
        };
        public State state;

        public List<Request> requests;

        public void Request(Request request)
        {
            lock(this)
            {
                requests.Add(request);
            }
        }

        public Request Pop()
        {
            lock(this)
            {
                Request temp = requests[0];
                requests.RemoveAt(0);
                return temp;
            }
        }

        public bool IsDead { get; private set; }

        public void Kill()
        {
            IsDead = true;
        }
    }
}
