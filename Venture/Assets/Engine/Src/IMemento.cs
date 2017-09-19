using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Engine
{
    public interface IMemento
    {
        /// <summary>
        /// SaveState must save a state of this object that it could be returned to.
        /// </summary>
        void SaveState();
        /// <summary>
        /// LoadState must load the latest state of this object.
        /// </summary>
        void LoadState();
        /// <summary>
        /// DumpState must dump the saved state(s) from memory to storage.
        /// </summary>
        void DumpState();
    }
}
