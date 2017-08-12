using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Engine.Src;
using Assets.General.Src;
using Assets.General.Src.SI;
using Assets.Resources.Src;
using UnityEngine;

namespace Assets.Station.Src.Updates
{
    public class PressurisationUpdate : UpdateDecorator
    {
        IPressurisable pressurisable;
        IConnections[] connections;
        Pascal pressure;
        Pascal desiredPressure;
        Kelvin temperature;
        IInventory inventory;
        ResourceStack[] resources;
        Metre3 volume;
        Mole molesOfGas;
        Mole molesofGasDesired;

        public PressurisationUpdate(VolatileObject obj) : base(obj)
        {
            if (obj is IPressurisable)
                pressurisable = obj as IPressurisable;
            else
                return;

            if (obj is IConnections)
                connections = (obj as IConnections).Connections();
            else
                return;

            pressure = pressurisable.Pressure();
            desiredPressure = pressurisable.DesiredPressure();
            temperature = pressurisable.Temperature();
            inventory = pressurisable.Inventory();
            volume = inventory.MaxVolume();
            molesOfGas = pressurisable.Moles();
            molesofGasDesired = pressurisable.MolesDesired();
        }

        //public Mole Moles()
        //{
        //    resources = inventory.Resources();
        //    molesOfGas = 0;
        //    foreach (ResourceStack gas in resources)
        //    {
        //        molesOfGas += gas.type.MolarMass * gas.volume;
        //    }
        //    return molesOfGas;
        //}

        public Pascal Pressure()
        {
            // IDEAL GAS LAW = PV=nRT
            // Where:
            // P = pressure in atm.
            // n = moles of gas
            // R = ideal gas constant (0.08206)
            // T = temperature in kelvin
            // V = volume in litres
            // Pressurisation is the sum of all the pressurisation forces of each gas, at the same temperature, and in the same volume, added together.
            // Which can be further simplified to say that the total pressure can be calculated by using the sum of all gases moles in the Ideal Gas Law.
            return (pressurisable.Moles() * 0.08206f * temperature) / volume;
        }

        public override void Update()
        {
            if (pressurisable == null || connections == null)
                return;

            // Pressurisation
            pressure = Pressure();

            // TODO Pressurisation Desired
            Pascal pressureToBe = pressure;
            // Determine how many moles of gas are necessary to achieve the desired pressure
            Mole desiredMoles = (desiredPressure * volume) / (0.08206f * temperature);
            // Now that I have determined the desired moles, I need to determine the composition of the atmosphere as is
            float[] percentMoles = new float[resources.Length];
            // As well I will compute how much of each gas I will need to get to the desired pressure
            float[] volumes = new float[resources.Length];
            // And I need to know what kinds of resources to take
            Resource[] resourceTypes = new Resource[resources.Length];
            for (int i = 0; i < percentMoles.Length; i++)
            {
                percentMoles[i] = (resources[i].type.MolarMass * resources[i].volume) / molesOfGas;
                volumes[i] = (percentMoles[i] * desiredMoles) / resources[i].type.MolarMass;
                resourceTypes[i] = resources[i].type;
            }
            // RESOURCE ACQUISITION
            // If pressure is less than the desired pressure, we need to perform logic to determine sources of more atmosphere
            if (pressure < desiredPressure)
            {
                IInventory[] inventories = new IInventory[connections.Length];
                int lengthActual = 0;

                // Primary blind search for IPressurisable
                for (int i = 0; i < connections.Length; i++)
                {
                    IPressurisable pressurisableConnected = connections[i].Self() as IPressurisable;
                    if (pressurisableConnected != null)
                    {
                        // Determine possible sources of the desired atmosphere
                        if (pressurisableConnected.Pressure() > pressurisableConnected.DesiredPressure())
                        {
                            float[] volumesPerConnection = new float[volumes.Length];

                            for (int j = 0; j < volumesPerConnection.Length; j++)
                            {
                                // Calculate how many moles excess the connected object has (divided by number of connections, to guarantee sharing)
                                Mole molesExcess = (pressurisableConnected.Moles() - pressurisableConnected.MolesDesired()) / (pressurisableConnected.Self() as IConnections).Connections().Length;
                                // Calculate volume to take of specific resource
                                Metre3 volumeToTake = (molesExcess * percentMoles[j]) / resources[j].type.MolarMass;
                                // Update volumesPerConnection to reflect the newly calculated volume
                                // TODO Pressurisation only allowing certain amounts to transfer based on volume of hardpoint's pressurisable space
                                volumesPerConnection[j] = Mathf.Min(volumes[j] / this.connections.Length, volumeToTake);
                            }

                            // TODO Pressurisation Resource Acquisition (Just Take? Or Keep to Requests)
                            //inventory.AddResources(pressurisableConnected.Inventory().RemoveResources(resourceTypes, volumesPerConnection));
                            //pressure = Pressure();

                            // If IInventories as well as all other interfaces used in updates are thread safe, 
                        }
                    }

                    IInventory inventoryConnected = connections[i].Self() as IInventory;
                    if (inventoryConnected != null)
                    {
                        inventories[lengthActual] = inventoryConnected;
                        lengthActual++;
                    }
                }

                // If the pressure we will have when we get what we have requested is still too low after only taking from adjacent overcapacity modules
                if (pressureToBe < desiredPressure)
                {
                    // The search moves into adjacent inventories, in an array we made at the same time we guessed our way through the entire list
                    for (int i = 0; i < lengthActual; i++)
                    {

                    }
                }
            }
        }
    }
}
