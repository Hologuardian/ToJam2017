using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Engine.Src
{
    public class MementoState <T>
    {
        int stamp;
        public int Stamp { get { return stamp; } set { stamp = value; } }

        T state;
        public T State { get { return state; } set { state = value; } }

        /// <summary>
        /// Constructs a MementoState that stores the time and value the memento had
        /// </summary>
        /// <param name="stamp"></param>
        /// <param name="state"></param>
        public MementoState(int stamp, T state)
        {
            this.stamp = stamp;
            this.state = state;
        }

        public static implicit operator T(MementoState<T> t)
        {
            return t.state;
        }
    }

    public class Memento <T>
    {
        private List<MementoState<T>> states = new List<MementoState<T>>();

        /// <summary>
        /// Constructs a new Memento
        /// </summary>
        public Memento()
        {

        }

        public void Set(T t)
        {
            states.Add(new MementoState<T>(DateTime.Now.Millisecond, t));
        }

        /// <summary>
        /// Getter
        /// </summary>
        /// <param name="t">The Memento being treated as a property</param>
        public static implicit operator T (Memento<T> t)
        {
            return t.states[t.states.Count-1];
        }
    }
}
