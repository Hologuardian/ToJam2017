using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Station
{
    public class Hardpoint : MonoBehaviour
    {
        public Module module;
        public Hardpoint connection;
    }

    public class Submodule : MonoBehaviour
    {
        public Module module;
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
