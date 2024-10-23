using System;
using System.Collections.Generic;

public class TeamParameters
{
    public int ID;                                  // Competitors'id
    public string Name;                             // work name
    public string School;                           // school name
    public string Type;                             // Competition type
    public int typeid;                              // type id
    public string[] Competitors = new string[3];    // Competitors' names
                                                    // include student1 to student3
    public string Teacher;                          // Teacher
    public Dictionary<string, int> typeID = new Dictionary<string, int>();

    // init
    public TeamParameters()
    {
        this.typeID["Cpp Programming"] = (int)TypeID.Cpp;
        this.typeID["Java Software Development"] = (int)TypeID.Java;
        this.typeID["Python Programming"] = (int)TypeID.Python;
        this.typeID["Web Application Development"] = (int)TypeID.Web;
        this.typeID["Network Security"] = (int)TypeID.Network;
        this.typeID["Embedded Design and Development"] = (int)TypeID.Embedded;
        this.typeID["Microcontroller Design and Development"] = (int)TypeID.Microcontroller;
        this.typeID["EDA Design and Development"] = (int)TypeID.EDA;
        this.typeID["IoT Design and Development"] = (int)TypeID.IoT;
        this.typeID["FPGA Design and Development"] = (int)TypeID.FPGA;
        this.typeID["5G Network Planning and Construction"] = (int)TypeID.fiveG;
    }
    public TeamParameters(int _id) 
    {
        this.typeID["Cpp Programming"] = (int)TypeID.Cpp;
        this.typeID["Java Software Development"] = (int)TypeID.Java;
        this.typeID["Python Programming"] = (int)TypeID.Python;
        this.typeID["Web Application Development"] = (int)TypeID.Web;
        this.typeID["Network Security"] = (int)TypeID.Network;
        this.typeID["Embedded Design and Development"] = (int)TypeID.Embedded;
        this.typeID["Microcontroller Design and Development"] = (int)TypeID.Microcontroller;
        this.typeID["EDA Design and Development"] = (int)TypeID.EDA;
        this.typeID["IoT Design and Development"] = (int)TypeID.IoT;
        this.typeID["FPGA Design and Development"] = (int)TypeID.FPGA;
        this.typeID["5G Network Planning and Construction"] = (int)TypeID.fiveG;
        this.ID = _id;
    }
    public TeamParameters(string _name, string _school,string student1, 
        string student2, string student3, string _teacher)
    {
        this.typeID["Cpp Programming"] = (int)TypeID.Cpp;
        this.typeID["Java Software Development"] = (int)TypeID.Java;
        this.typeID["Python Programming"] = (int)TypeID.Python;
        this.typeID["Web Application Development"] = (int)TypeID.Web;
        this.typeID["Network Security"] = (int)TypeID.Network;
        this.typeID["Embedded Design and Development"] = (int)TypeID.Embedded;
        this.typeID["Microcontroller Design and Development"] = (int)TypeID.Microcontroller;
        this.typeID["EDA Design and Development"] = (int)TypeID.EDA;
        this.typeID["IoT Design and Development"] = (int)TypeID.IoT;
        this.typeID["FPGA Design and Development"] = (int)TypeID.FPGA;
        this.typeID["5G Network Planning and Construction"] = (int)TypeID.fiveG;

        this.Name = _name;
        this.School = _school;
        this.Competitors[0] = student1;
        this.Competitors[1] = student2;
        this.Competitors[2] = student3;
        this.Teacher = _teacher;
    }
    public TeamParameters(string _name, string _school, string _type,
        string student1, string student2, string student3, string _teacher)
    {
        this.typeID["Cpp Programming"] = (int)TypeID.Cpp;
        this.typeID["Java Software Development"] = (int)TypeID.Java;
        this.typeID["Python Programming"] = (int)TypeID.Python;
        this.typeID["Web Application Development"] = (int)TypeID.Web;
        this.typeID["Network Security"] = (int)TypeID.Network;
        this.typeID["Embedded Design and Development"] = (int)TypeID.Embedded;
        this.typeID["Microcontroller Design and Development"] = (int)TypeID.Microcontroller;
        this.typeID["EDA Design and Development"] = (int)TypeID.EDA;
        this.typeID["IoT Design and Development"] = (int)TypeID.IoT;
        this.typeID["FPGA Design and Development"] = (int)TypeID.FPGA;
        this.typeID["5G Network Planning and Construction"] = (int)TypeID.fiveG;

        this.Name = _name;
        this.School = _school;
        this.Type = _type;
        int tmp = typeID[Type];
        this.typeid = tmp;
        this.Competitors[0] = student1;
        this.Competitors[1] = student2;
        this.Competitors[2] = student3;
        this.Teacher = _teacher;
    }

    public TeamParameters(int _id, string _name, string _school, string _type,
        string student1, string student2, string student3, string _teacher)
    {
        this.typeID["Cpp Programming"] = (int)TypeID.Cpp;
        this.typeID["Java Software Development"] = (int)TypeID.Java;
        this.typeID["Python Programming"] = (int)TypeID.Python;
        this.typeID["Web Application Development"] = (int)TypeID.Web;
        this.typeID["Network Security"] = (int)TypeID.Network;
        this.typeID["Embedded Design and Development"] = (int)TypeID.Embedded;
        this.typeID["EDA Design and Development"] = (int)TypeID.EDA;
        this.typeID["IoT Design and Development"] = (int)TypeID.IoT;
        this.typeID["FPGA Design and Development"] = (int)TypeID.FPGA;
        this.typeID["5G Network Planning and Construction"] = (int)TypeID.fiveG;

        this.ID = _id;
        this.Name = _name;
        this.School = _school;
        this.Type = _type;
        int tmp = typeID[Type];
        this.typeid = tmp;
        this.Competitors[0] = student1;
        this.Competitors[1] = student2;
        this.Competitors[2] = student3;
        this.Teacher = _teacher;
    }
    public TeamParameters(int _id, string _name, string _school, string _type, int _typeID, 
        string student1, string student2, string student3, string _teacher) 
    {
        this.typeID["Cpp Programming"] = (int)TypeID.Cpp;
        this.typeID["Java Software Development"] = (int)TypeID.Java;
        this.typeID["Python Programming"] = (int)TypeID.Python;
        this.typeID["Web Application Development"] = (int)TypeID.Web;
        this.typeID["Network Security"] = (int)TypeID.Network;
        this.typeID["Embedded Design and Development"] = (int)TypeID.Embedded;
        this.typeID["EDA Design and Development"] = (int)TypeID.EDA;
        this.typeID["IoT Design and Development"] = (int)TypeID.IoT;
        this.typeID["FPGA Design and Development"] = (int)TypeID.FPGA;
        this.typeID["5G Network Planning and Construction"] = (int)TypeID.fiveG;
        this.ID = _id;
        this.Name = _name;
        this.School = _school;
        this.Type = _type;
        this.typeid = _typeID;
        this.Competitors[0] = student1;
        this.Competitors[1] = student2;
        this.Competitors[2] = student3;
        this.Teacher = _teacher;
    }

    public string ToString()
    {
        return this.ID.ToString() + " " + this.Name + " " + this.School + " " + this.Type + " " +
            this.Competitors[0] + " " + this.Competitors[1] + " " + this.Competitors[2] + " " + this.Teacher;
    }

    public string toString()
    {
        return this.ID.ToString() + "," + this.Name + "," + this.School + "," + this.Type + "," +
            this.Competitors[0] + "," + this.Competitors[1] + "," + this.Competitors[2] + "," + this.Teacher + "\n";
    }
}
