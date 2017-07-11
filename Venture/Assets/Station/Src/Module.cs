using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Engine.Src;

namespace Station
{
    // TODO place in own Hardpoint.cs
    public class Hardpoint : MonoBehaviour
    {
        public Module module;
        public Hardpoint connection;
    }

    // TODO place in own Submodule.cs
    public class Submodule : MonoBehaviour
    {
        public Module module;
    }

    public class VolatileModule : VolatileObject
    {
        // Properties
        // Ensure proper care is taken to considering which must be Mementos and which can be generic

        // Methods
        /// <summary>
        /// Update must be thread safe
        /// </summary>
        public void Update()
        {
            lock(this)
            {
                // TODO generic module logic
                this.OverrideUpdate();
            }
        }

        /// <summary>
        /// This method is the overridable method used to give VolatileModule child classes actual logic, while gauranteeing thread safety, as Update locks this before calling OverrideUpdate
        /// </summary>
        public abstract void OverrideUpdate();
    }

    public class Module : MonoBehaviour
    {
        public Hardpoint[] hardpoints;
        public Submodule[] submodules;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
