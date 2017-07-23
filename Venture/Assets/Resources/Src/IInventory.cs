using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Resources
{
    public interface IInventory
    {
        /// <summary>
        /// Used to respond the maximum size of the inventory
        /// </summary>
        /// <returns>
        /// The maximum volume this inventory can hold in m3
        /// </returns>
        float MaxVolume();

        /// <summary>
        /// 
        /// </summary>
        /// <returns>
        /// The current volume of total items within the inventory
        /// </returns>
        float CurrentVolume();

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
        ResourceStack[] GetResource(Resource resource);

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
        /// Creates a resource stack from inventory's hold
        /// </summary>
        /// <param name="resource">
        /// Type of resource to be removed.
        /// </param>
        /// <param name="volume">
        /// Requested volume to be removed, not garunteed to be this size.
        /// </param>
        /// <returns></returns>
        ResourceStack RemoveResource(Resource resource, float volume);
    }
}
