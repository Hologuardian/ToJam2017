using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;


public enum Specialisations
{
    Farming = 0,
    Mining = 1,
    Hauling = 2,
    Fabricating = 3,
    Trading = 4
}

public class Agent : MonoBehaviour
{
    const string Inventory = "inventory", Employees = "Employees", CostPerMonth = "CostPerMonth";
    public Blackboard AgentBlackboard;
    public Inventory inventory;

    // Use this for initialization
    public void Launch()
    {
        // ask station what resource. 
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static Agent Factory()
    {
        Specialisations Specialisation = new Specialisations();
        Specialisation = (Specialisations)UnityEngine.Random.Range(0, Enum.GetNames(typeof(Specialisations)).Length);

        Agent agent = new Agent();
        agent.AgentBlackboard.Add("Name", new BlackboardValue() { Name = "Name", Value = "Agent Name" });
        agent.AgentBlackboard.Add("Inventory", new BlackboardValue() { Name = "Inventory", Value = agent.inventory });
        agent.inventory.Start();
        List<Employee> Employees = new List<Employee>();
        int randomNumEmployees = UnityEngine.Random.Range(1, 100);
        for (int i = 0; i < randomNumEmployees; i++)
        {
            Employees.Add(new Employee());
            Employees[i].Birth(Specialisation,);
        }
        agent.AgentBlackboard.Add("Employees", new BlackboardValue() { Name = "Employees", Value = Employees });
        agent.AgentBlackboard.Add("CostPerMonth", new BlackboardValue() { Name = "CostPerMonth", Value = Employees.Count * UnityEngine.Random.Range(4000, 6000) });

        return agent;
    }

}
