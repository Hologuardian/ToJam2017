using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Engine;

namespace Assets.Station
{
    public class Hardpoint : MonoBehaviour
    {
        public Module module;
        public Hardpoint connection;

        public VolatileHardpoint volatileHardpoint;
    }
}
