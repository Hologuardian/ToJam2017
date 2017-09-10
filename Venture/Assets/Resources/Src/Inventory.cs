using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.General.Src.SI;

namespace Assets.Resources.Src
{
    public class Inventory : IInventory
    {
        private Dictionary<Resource, ResourceStack> items;

        public ResourceStack AddResource(ResourceStack resource)
        {
            throw new NotImplementedException();
        }

        public ResourceStack[] AddResources(ResourceStack[] resource)
        {
            throw new NotImplementedException();
        }

        public float CurrentVolume()
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

        public float MaxVolume()
        {
            throw new NotImplementedException();
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
