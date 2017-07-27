using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Engine.Src;
using Resources;

namespace Assets.Station.Src
{
    public class VolatileHardpoint : VolatileObject
    {
        private IInventory filter;
        private ResourceStack[] filterArray;
        public IInventory Filter
        {
            get
            {
                return filter;
            }
            set
            {
                filter = value;
                filterArray = filter.Resources();
            }
        }

        public ResourceStack[] FilterInventory (IInventory incoming)
        {
            // This needs to iterate across the filter inventory
            // And remove a percentage weighted volume of the filter resources
            float filterVolume = Filter.CurrentVolume();

            ResourceStack[] resources = new ResourceStack[filterArray.Length];

            int i = 0;
            foreach (ResourceStack stack in filterArray)
            {
                // Otherwise the long way:
                if (incoming.GetResource(stack.type).volume > 0)
                {
                    resources[i] = new ResourceStack() { type = stack.type, volume = stack.volume * (stack.volume / filterVolume) };
                }
                i++;
            }

            return resources;
        }

        public ResourceStack[] FilterResourceStackArray(ResourceStack[] incoming)
        {
            // This needs to iterate across the filter inventory
            // And remove a percentage weighted volume of the filter resources
            float filterVolume = Filter.CurrentVolume();

            ResourceStack[] resources = new ResourceStack[filterArray.Length];

            int i = 0;
            foreach (ResourceStack stack in filterArray)
            {
                int j = 0;
                foreach (ResourceStack incStack in incoming)
                {
                    if (incStack.type == stack.type)
                    {
                        if (incoming[j].volume > 0)
                        {
                            resources[i] = new ResourceStack() { type = stack.type, volume = stack.volume * (stack.volume / filterVolume) };
                        }
                    }
                    j++;
                }
                i++;
            }

            return resources;
        }
    }
}
