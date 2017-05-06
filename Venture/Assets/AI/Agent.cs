using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;


public enum Specialisations {
    Farming=0,
    Mining=1,
    Hauling=2,
    Fabricating=3,
    Trading=4
}

public class Agent : MonoBehaviour {
    public static class Literals{
        public const string 
            Name = "Name", 
            CostPerMonth = "CostPerMonth",
            Employees = "Employees",
            EmployeesEfficiencyMax = "EmployeesEfficiencyMax",
            EmployeesEfficiencyMin = "EmployeesEfficiencyMin", 
            EmployeesEfficiencyMean = "EmployeesEfficiencyMean", 
            EmployeesEfficiencyMedian = "EmployeesEfficiencyMedian", 
            EmployeesEfficiencyMode = "EmployeesEfficiencyMode";

    }


    public Blackboard general = new Blackboard();
    
	// Update is called once per frame
	void Update () {
		
	}
    
    public static Agent Factory() {
        Specialisations Specialisation = new Specialisations();
        Specialisation = (Specialisations) UnityEngine.Random.Range(0, Enum.GetNames(typeof(Specialisations)).Length);
        Agent agent = new Agent();
        agent.general.Add(Literals.Name, new BlackboardValue() { Name = "Name", Value = "Agent Name" });
        List<Employee> Employees = new List<Employee>();
        int randomNumEmployees = UnityEngine.Random.Range(1, 100);

        //setting valuse for ui
        float EmployeesEfficiencyMax=0, EmployeesEfficiencyMin=3, EmployeesEfficiencyMean=0, EmployeesEfficiencyMedian=0, EmployeesEfficiencyMode=0;
        Dictionary<string, float> ModeNumbers = new Dictionary<string, float>();
        for (int i = 0; i < randomNumEmployees; i++) {
            Employees.Add(new Employee());
            Employees[i].Birth(Specialisation,agent);
            EmployeesEfficiencyMean += (float) Employees[i].EmployeeInfo["Efficiency"].Value;
            EmployeesEfficiencyMax = ((float)Employees[i].EmployeeInfo["Efficiency"].Value > EmployeesEfficiencyMax) ? (float)Employees[i].EmployeeInfo["Efficiency"].Value : EmployeesEfficiencyMax;
            EmployeesEfficiencyMin = ((float)Employees[i].EmployeeInfo["Efficiency"].Value < EmployeesEfficiencyMin) ? (float)Employees[i].EmployeeInfo["Efficiency"].Value : EmployeesEfficiencyMin;

            if (ModeNumbers.ContainsKey((string)Employees[i].EmployeeInfo["Efficiency"].Value)){
                ModeNumbers[(string)Employees[i].EmployeeInfo["Efficiency"].Value]++;
            }
            else{
                ModeNumbers.Add((string)Employees[i].EmployeeInfo["Efficiency"].Value, 1);
            }
        }
        EmployeesEfficiencyMean /= Employees.Count;
        EmployeesEfficiencyMedian = (float)Employees[Employees.Count/2].EmployeeInfo["Efficiency"].Value;
        float ModeNumbersTemp = 0;
        foreach (KeyValuePair<string, float> pair in ModeNumbers) {
            if (ModeNumbersTemp > pair.Value) {
                EmployeesEfficiencyMode = pair.Value;
            }
        }

        agent.general.Add(Literals.Employees, new BlackboardValue() { Name = "Employees", Value = Employees });
        agent.general.Add("EmployeesEfficiencyMin", new BlackboardValue() { Name = "EmployeesEfficiencyMin", Value = EmployeesEfficiencyMin });
        agent.general.Add("EmployeesEfficiencyMax", new BlackboardValue() { Name = "EmployeesEfficiencyMax", Value = EmployeesEfficiencyMax });
        agent.general.Add("EmployeesEfficiencyMean", new BlackboardValue() { Name = "EmployeesEfficiencyMean", Value = EmployeesEfficiencyMean });
        agent.general.Add("EmployeesEfficiencyMedian", new BlackboardValue() { Name = "EmployeesEfficiencyMedian", Value = EmployeesEfficiencyMedian });
        agent.general.Add("EmployeesEfficiencyMode", new BlackboardValue() { Name = "EmployeesEfficiencyMode", Value = EmployeesEfficiencyMode });

        agent.general.Add("CostPerMonth", new BlackboardValue() { Name = "CostPerMonth", Value = Employees.Count * UnityEngine.Random.Range(4000,6000)});
        return agent;
    }

}
