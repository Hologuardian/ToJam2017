using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Assets.Engine.Src;

namespace Assets.Station.Src.Modules
{
    public class CommandModule : Module
    {
        /// <summary>
        /// Clock Speed defines the number of updates per second (at standard simulation speed) this command module will experience, which subsequently is the number of times it will cause an update cascade
        /// </summary>
        [Range(1,120)]
        [Tooltip("Clock Speed defines the number of updates per second (at standard simulation speed) this command module will cause.")]
        public float clockSpeed = 10;
        private float clockSpeedInv;
        public float clockCurrent = 0;

        private void Start()
        {
            clockSpeedInv = 1 / clockSpeed;
        }

        public void Update()
        {
            clockCurrent += Time.deltaTime;

            if (clockCurrent > clockSpeedInv * Globals.SimulationSpeed)
            {
                clockCurrent -= clockSpeedInv * Globals.SimulationSpeed;
                TaskHelper.TaskManager.QueueTask(new TaskNode(threaded.Update, "moduleUpdate"), (float)TaskPriority.Medium);
            }
        }
    }
}
