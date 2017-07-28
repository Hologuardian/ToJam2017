using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Engine.Src;

namespace Assets.General.Src
{
    /// <summary>
    /// Statistic is a float Memento with a built in Maximum value
    /// </summary>
    public class Statistic : Memento<float>
    {
        /// <summary>
        /// The maximum value this statistic can ever be set to.
        /// </summary>
        public float Maximum { get; set; }

        public Statistic(string name, float maximum, float current) : base(name)
        {
            Maximum = maximum;

            if (current < Maximum)
                Set(current);
            else
                Set(Maximum);
        }

        public override void Set(float t)
        {
            if (t < Maximum)
                base.Set(t);
            else
                Set(Maximum);
        }
    }
}
