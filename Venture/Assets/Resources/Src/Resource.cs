using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Resources
{
    [Serializable]
    public class Resource
    {
        public Resource()
        {
            this.Name = "";
            this.volume = 0;
            this.Density = 0;
            this.value = 0;
            this.MolarMass = 0.0f;
        }
        public Resource(string Name, float Volume, float Mass, float Density, float Value, float MolarMass)
        {
            this.Name = Name;
            this.volume = Volume;
            this.Density = Density;
            this.value = Value;
            this.MolarMass = MolarMass;
        }
        public Resource(Resource resource)
        {
            this.Name = resource.Name;
            this.volume = resource.Volume;
            this.Density = resource.Density;
            this.value = resource.Value;
            this.MolarMass = resource.MolarMass;
        }

        public Resource Mols(int mols)
        {
            Mass = MolarMass * 0.001f * mols;
            return this;
        }

        public Resource PercentMass(float Mass, float percent)
        {
            this.Mass = Mass * percent;
            return this;
        }

        public string Name;

        /// <summary>
        /// How much of a thing we have
        /// </summary>
        public float Volume
        {
            get { return volume; }
            set { this.volume = value; }
        }

        /// <summary>
        /// How much this stack weighs
        /// </summary>
        public float Mass
        {
            get { return Volume * Density; }
            set { Volume = value / Density; }
        }
        /// <summary>
        /// How dense this item is
        /// </summary>
        public float Density
        {
            get { return density; }
            set { density = value; }
        }
        /// <summary>
        /// How much each m3 of this item is worth
        /// </summary>
        public float Value
        {
            get { return value; }
            set { this.value = value; }
        }
        /// <summary>
        /// How much one Mol of this item weighs, used for chemistry equations
        /// </summary>
        public float MolarMass
        {
            get { return molarMass; }
            set { this.molarMass = value; }
        }
        /// <summary>
        /// How much this stack is worth
        /// </summary>
        public float GrossValue
        {
            get { return value * Volume; }
        }

        [SerializeField]
        private float volume;
        [SerializeField]
        private float density;
        [SerializeField]
        private float value;
        [SerializeField]
        private float molarMass;
    }
}