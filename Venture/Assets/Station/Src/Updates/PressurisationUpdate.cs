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
        }

        public Mole Moles()
        {
            resources = inventory.Resources();
            molesOfGas = 0;
            foreach (ResourceStack gas in resources)
            {
                molesOfGas += gas.type.MolarMass * gas.volume;
            }
            return molesOfGas;
        }

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
            return (Moles() * 0.08206f * temperature) / volume;
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
            // And determine possible sources of the desired atmosphere
            // With a primary blind search for IPressurisable
            IInventory[] inventories = new IInventory[connections.Length];
            int lengthActual = 0;
            foreach (IConnections connection in connections)
            {
                IPressurisable pressurisableConnected = connection.Self() as IPressurisable;
                if (pressurisableConnected != null)
                {
                    if (pressurisableConnected.Pressure() > pressurisableConnected.DesiredPressure() && pressure < desiredPressure)
                    {
                        float[] volumesPerConnection = new float[volumes.Length];

                        for (int i = 0; i < volumesPerConnection.Length; i++)
                        {
                            volumesPerConnection[i] = Mathf.Max(volumes[i] / connections.Length);// TODO Pressurisation need some logic for getting amount of volume I can take maximum per resource from this pressure, pressurisableConnected.().GetResource(resourceTypes[i]).volume);
                        }

                        // Take the resources needed
                        inventory.AddResources(pressurisableConnected.Inventory().RemoveResources(resourceTypes, volumesPerConnection));
                        pressure = Pressure();
                    }
                }
                IInventory inventoryConnected = connection.Self() as IInventory;
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
