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
        const string Employees = "Employees", 
                    CostPerMonth = "CostPerMonth";

    }


    public Blackboard general = new Blackboard();
    
	// Update is called once per frame
	void Update () {
		
	}
    
    public static Agent Factory() {
        Specialisations Specialisation = new Specialisations();
        Specialisation = (Specialisations) UnityEngine.Random.Range(0, Enum.GetNames(typeof(Specialisations)).Length);

        Agent agent = new Agent();
        agent.general.Add("Name", new BlackboardValue() { Name = "Name", Value = "Agent Name" });
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

        agent.general.Add("Employees", new BlackboardValue() { Name = "Employees", Value = Employees });
        agent.general.Add("CostPerMonth", new BlackboardValue() { Name = "CostPerMonth", Value = Employees.Count * UnityEngine.Random.Range(4000,6000)});
        return agent;
    }

}
