//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Employee {
//    public Blackboard EmployeeInfo;

//    public void Birth(Specialisations Role,string Agent) {
//        EmployeeInfo.Add("Name", new BlackboardValue() { Name = "Name", Value = Getname()});
//        EmployeeInfo.Add("Agent", new BlackboardValue() { Name = "Agent", Value = Agent });
//        EmployeeInfo.Add("Age", new BlackboardValue() { Name = "Age", Value = Random.Range(1,1000)});
//        EmployeeInfo.Add("Gender", new BlackboardValue() { Name = "Gender", Value = Getgender()});
//        EmployeeInfo.Add("Height", new BlackboardValue() { Name = "Height", Value = Random.Range(1, 9)});
//        EmployeeInfo.Add("Specialisation", new BlackboardValue() { Name = "Specialisation", Value = Role});

//        //string Name = (string)EmployeeInfo["Name"].Value;
//    }
//    string Getname() {
//        System.IO.StreamReader file = new System.IO.StreamReader("Names.txt");
//        string name = "";
//        int getline = Random.Range(0, 923);
//        for (int i = 0; i < getline; i++)
//        {
//            name = file.ReadLine();
//        }
//        return name;
//    }
//    string Getlastname()
//    {
//        System.IO.StreamReader file = new System.IO.StreamReader("Names.txt");
//        string lastname="";
//        int getline = Random.Range(0, 923);
//        for (int i = 0; i < getline; i++)
//        {
//            lastname = file.ReadLine();
//        }
//        if (lastname.Length < 4) {
//            string lastnameB="";
//            getline = Random.Range(0, 923);
//            for (int i = 0; i < getline; i++)
//            {
//                lastnameB = file.ReadLine();
//            }
//            lastname = lastname + lastnameB.ToLower();
//        }
//        return lastname;
//    }
//    string Getgender()
//    {
//        System.IO.StreamReader file = new System.IO.StreamReader("Genders.txt");
//        string gender = "";
//        int getline = Random.Range(0, 57);
//        for (int i = 0; i < getline; i++)
//        {
//            gender = file.ReadLine();
//        }
//        return gender;
//    }

//}
