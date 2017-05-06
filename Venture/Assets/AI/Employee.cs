using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Employee
{
    public Blackboard general;
    public void Birth(Specialisations Role, Agent _ParentAgent)
    {
        general.Add(Consts.Employee.ParentAgent, new BlackboardValue() { Name = "ParentAgent", Value = _ParentAgent });
        general.Add(Consts.Employee.Name, new BlackboardValue() { Name = "Name", Value = Getname() });
        general.Add(Consts.Employee.LastName, new BlackboardValue() { Name = "Last Name", Value = Getlastname() });
        general.Add(Consts.Employee.Age, new BlackboardValue() { Name = "Age", Value = Random.Range(1, 1000) });
        general.Add(Consts.Employee.Gender, new BlackboardValue() { Name = "Gender", Value = Getgender() });
        general.Add(Consts.Employee.Height, new BlackboardValue() { Name = "Height", Value = Random.Range(1, 9) });
        general.Add(Consts.Employee.Specialisation, new BlackboardValue() { Name = "Specialisation", Value = Role });
        float tempEfficiency = Random.Range(0.0f, 1.0f) + Random.Range(0.0f, 1.0f);
        general.Add(Consts.Employee.Efficiency, new BlackboardValue() { Name = "Efficiency", Value = (tempEfficiency >= 1) ? tempEfficiency : Mathf.Lerp(0.5f, 1, tempEfficiency) });
        //thanks hal
        general.Add(Consts.Employee.HungerMax, new BlackboardValue() { Name = "HungerMax", Value = Random.Range(168, 168 * 2) });
        general.Add(Consts.Employee.Hunger, new BlackboardValue() { Name = "Hunger", Value = 0 });
        general.Add(Consts.Employee.Happynes, new BlackboardValue() { Name = "Happynes", Value = Random.Range(-10, 10) });
        float HappynesGoalTemp = Random.Range(0.0f, 1.0f) + Random.Range(0.0f, 1.0f);
        general.Add(Consts.Employee.HappynesGoal, new BlackboardValue() { Name = "HappynesGoal", Value = (HappynesGoalTemp >= 1) ? HappynesGoalTemp : Mathf.Lerp(0.5f, 1, HappynesGoalTemp) });
        //string Name = (string)EmployeeInfo["Name"].Value;
    }
    string Getname()
    {
        System.IO.StreamReader file = new System.IO.StreamReader("Names.txt");
        string name = "";
        int getline = Random.Range(0, 923);
        for (int i = 0; i < getline; i++)
        {
            name = file.ReadLine();
        }
        return name;
    }
    string Getlastname()
    {
        System.IO.StreamReader file = new System.IO.StreamReader("Names.txt");
        string lastname = "";
        int getline = Random.Range(0, 923);
        for (int i = 0; i < getline; i++)
        {
            lastname = file.ReadLine();
        }
        if (lastname.Length < 4)
        {
            string lastnameB = "";
            getline = Random.Range(0, 923);
            for (int i = 0; i < getline; i++)
            {
                lastnameB = file.ReadLine();
            }
            lastname = lastname + lastnameB.ToLower();
        }
        return lastname;
    }
    string Getgender()
    {
        System.IO.StreamReader file = new System.IO.StreamReader("Genders.txt");
        string gender = "";
        int getline = Random.Range(0, 57);
        for (int i = 0; i < getline; i++)
        {
            gender = file.ReadLine();
        }
        return gender;
    }

}