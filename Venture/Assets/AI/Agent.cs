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

public class Agent : MonoBehaviour {

    public Blackboard general = new Blackboard();

    // Update is called once per frame
    void Update()
    {

    }

    public static Agent Factory()
    {
        List<Employee> Employees = new List<Employee>();
        Dictionary<string, float> ModeNumbers = new Dictionary<string, float>();
        Specialisations Specialisation = new Specialisations();
        float EmployeesEfficiencyMax = 0, EmployeesEfficiencyMin = 3, EmployeesEfficiencyMean = 0, EmployeesEfficiencyMedian = 0, EmployeesEfficiencyMode = 0;
        int randomNumEmployees = UnityEngine.Random.Range(1, 100);
        Agent agent = new Agent();

        Specialisation = (Specialisations) UnityEngine.Random.Range(0, Enum.GetNames(typeof(Specialisations)).Length);
        //setting valuse for ui
        for (int i = 0; i < randomNumEmployees; i++)
        {
            Employees.Add(new Employee());
            EmployeesEfficiencyMean += (float)Employees[i].EmployeeInfo["Efficiency"].Value;
            EmployeesEfficiencyMax = ((float)Employees[i].EmployeeInfo["Efficiency"].Value > EmployeesEfficiencyMax) ? (float)Employees[i].EmployeeInfo["Efficiency"].Value : EmployeesEfficiencyMax;
            EmployeesEfficiencyMin = ((float)Employees[i].EmployeeInfo["Efficiency"].Value < EmployeesEfficiencyMin) ? (float)Employees[i].EmployeeInfo["Efficiency"].Value : EmployeesEfficiencyMin;

            if (ModeNumbers.ContainsKey((string)Employees[i].EmployeeInfo["Efficiency"].Value))
            {
                ModeNumbers[(string)Employees[i].EmployeeInfo["Efficiency"].Value]++;
            }
            else
            {
                ModeNumbers.Add((string)Employees[i].EmployeeInfo["Efficiency"].Value, 1);
            }
        }
        EmployeesEfficiencyMean /= Employees.Count;
        EmployeesEfficiencyMedian = (float)Employees[Employees.Count / 2].EmployeeInfo["Efficiency"].Value;
        float ModeNumbersTemp = 0;
        foreach (KeyValuePair<string, float> pair in ModeNumbers)
        {
            if (ModeNumbersTemp > pair.Value)
            {
                EmployeesEfficiencyMode = pair.Value;
            }
        }
        //blackboard
        agent.general.Add(Consts.Name, new BlackboardValue() { Name = "Name", Value = "Agent Name" });
        agent.general.Add(Consts.Specialisation, new BlackboardValue() { Name = "Specialisation", Value = Specialisation });
        agent.general.Add(Consts.Employees, new BlackboardValue() { Name = "Employees", Value = Employees });
        agent.general.Add(Consts.EmployeesEfficiencyMin, new BlackboardValue() { Name = "EmployeesEfficiencyMin", Value = EmployeesEfficiencyMin });
        agent.general.Add(Consts.EmployeesEfficiencyMax, new BlackboardValue() { Name = "EmployeesEfficiencyMax", Value = EmployeesEfficiencyMax });
        agent.general.Add(Consts.EmployeesEfficiencyMean, new BlackboardValue() { Name = "EmployeesEfficiencyMean", Value = EmployeesEfficiencyMean });
        agent.general.Add(Consts.EmployeesEfficiencyMedian, new BlackboardValue() { Name = "EmployeesEfficiencyMedian", Value = EmployeesEfficiencyMedian });
        agent.general.Add(Consts.EmployeesEfficiencyMode, new BlackboardValue() { Name = "EmployeesEfficiencyMode", Value = EmployeesEfficiencyMode });
        agent.general.Add(Consts.CostPerMonth, new BlackboardValue() { Name = "CostPerMonth", Value = Employees.Count * UnityEngine.Random.Range(4000,6000)});
       
        foreach (Employee employee in (agent.general[Consts.Employees].Value as List<Employee>)) {
            employee.Birth(Specialisation, agent);
        }
        return agent;
    }

}