using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.General.SI;

namespace Assets.Resources.Src
{
    public interface IInventory
    {
        /// <summary>
        /// Used to respond the maximum size of the inventory
        /// </summary>
        /// <returns>
        /// The maximum volume this inventory can hold in m3
        /// </returns>
        Metre3 MaxVolume();

        /// <summary>
        /// Used to respond the maximum size of the inventory
        /// </summary>
        /// <returns>
        /// The maximum volume this inventory can hold in m3
        /// </returns>
        void SetMaxVolume(Metre3 volume);

        /// <summary>
        /// 
        /// </summary>
        /// <returns>
        /// The current volume of total items within the inventory
        /// </returns>
        Metre3 CurrentVolume();

        /// <summary>
        /// Get all resources in the inventory, does not remove them all.
        /// </summary>
        /// <returns>
        /// An array of all resources within the inventory.
        /// </returns>
        ResourceStack[] Resources();

        /// <summary>
        /// Gets a single resorce from the inventory, does not remove it.
        /// </summary>
        /// <param name="resource">
        /// resource Type to be removed
        /// </param>
        /// <returns>
        /// A resource stack of the requested type, resource type returned will be a void resouce if not found
        /// </returns>
        ResourceStack GetResource(Resource resource);

        /// <summary>
        /// Gets a single resorce from the inventory, does not remove it.
        /// </summary>
        /// <param name="resource">
        /// resource Type to be removed
        /// </param>
        /// <returns>
        /// A resource stack of the requested type, resource type returned will be a void resouce if not found
        /// </returns>
        ResourceStack[] GetResources(Resource[] resources);

        /// <summary>
        /// Adds a resource stack to the inventory
        /// </summary>
        /// <param name="resource">
        /// Resource stack added
        /// </param>
        /// <returns>
        /// If the inventory is full, any excess resouce that could not be added will be returned
        /// </returns>
        ResourceStack AddResource(ResourceStack resource);

        /// <summary>
        /// Adds several resource stacks to the inventory
        /// </summary>
        /// <param name="resource">
        /// Resource stacks to be added
        /// </param>
        /// <returns>
        /// If the inventory is full, any excess resouce that could not be added will be returned
        /// </returns>
        ResourceStack[] AddResources(ResourceStack[] resource);

        /// <summary>
        /// Creates a resource stack from inventory's hold
        /// </summary>
        /// <param name="resource">
        /// Type of resource to be removed.
        /// </param>
        /// <param name="volume">
        /// Requested volume to be removed, not garunteed to be this size.
        /// </param>
        /// <returns></returns>
        ResourceStack RemoveResource(Resource resource, Metre3 volume);


        /// <summary>
        /// Removes multiple resources from inventory.
        /// </summary>
        /// <param name="resources">
        /// List of resources to remove
        /// </param>
        /// <param name="volumes">
        /// Amounts of each resource to remove
        /// </param>
        /// <returns></returns>
        ResourceStack[] RemoveResources(Resource[] resources, Metre3[] volumes);

        /// <summary>
        /// Removes all resources from the inventory
        /// </summary>
        /// <returns>
        ///  Array of resource stacks
        /// </returns>
        ResourceStack[] RemoveResources();

        /// <summary>
        /// 
        /// </summary>
        /// <returns>
        /// 
        /// </returns>
        Gram TotalMass();
    }
}
