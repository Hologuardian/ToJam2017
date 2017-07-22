using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Engine.Src
{
    public class VolatileObject
    {
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
