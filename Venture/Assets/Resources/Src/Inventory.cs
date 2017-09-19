using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.General.SI;

namespace Assets.Resources.Src
{
    public class Inventory : IInventory
    {
        private Dictionary<Resource, ResourceStack> items;

        private Metre3 maxVolume;
        private Metre3 currentVolume;

        public Inventory(Metre3 MaxVolume)
        {
            items = new Dictionary<Resource, ResourceStack>();
            this.MaxVolume = MaxVolume;
        }

        public ResourceStack AddResource(ResourceStack resource)
        {
            deltaVolume = maxVolume - currentVolume;
            if (currentVolume + resource.volume <= maxVolume)
            {
                if (items.ContainsKey(resource.type))
                {
                    items[resource.type].volume += resource.volume;
                }
                items.Add(resource.type, resource);
                return null;
            }
            else
            {
                if (items.ContainsKey(resource.type))
                {
                    items[resource.type].volume += deltaVolume;
                }
                items.Add(resource.type, new ResourceStack(resource.type, deltaVolume));
                resource.volume -= deltaVolume;
                return resource;
            }
        }

        public ResourceStack[] AddResources(ResourceStack[] resource)
        {
            throw new NotImplementedException();
        }

        public Metre3 CurrentVolume()
        {
            throw new NotImplementedException();
        }

        public ResourceStack GetResource(Resource resource)
        {
            throw new NotImplementedException();
        }

        public ResourceStack[] GetResources(Resource[] resources)
        {
            throw new NotImplementedException();
        }

        public Metre3 MaxVolume()
        {
            return maxVolume;
        }

        public Metre3 SetMaxVolume(Metre volume)
        {
            maxVolume = volume;
        }

        public ResourceStack RemoveResource(Resource resource, float volume)
        {
            throw new NotImplementedException();
        }

        public ResourceStack[] RemoveResources(Resource[] resources, float[] volumes)
        {
            throw new NotImplementedException();
        }

        public ResourceStack[] RemoveResources()
        {
            throw new NotImplementedException();
        }

        public ResourceStack[] Resources()
        {
            throw new NotImplementedException();
        }

        public Gram TotalMass()
        {
            throw new NotImplementedException();
        }
    }
}
