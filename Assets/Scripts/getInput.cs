using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class getInput : MonoBehaviour
{
    public TMP_InputField teamname;
    public TMP_InputField school;
    public TMP_InputField type;
    public TMP_InputField student1;
    public TMP_InputField student2;
    public TMP_InputField student3;
    public TMP_InputField teacher;

    public string _name;
    public string _school;
    public string _type;
    public string _student1;
    public string _student2;
    public string _student3;
    public string _teacher;
    public int _id;

    public Button add;
    public Button cancel;
    public Database database;

    // Start is called before the first frame update
    void Start()
    {
        teamname.onEndEdit.AddListener(getInputName);
        school.onEndEdit.AddListener(getInputSchool);
        type.onEndEdit.AddListener(getInputType); 
        student1.onEndEdit.AddListener(getInputStu1);
        student2.onEndEdit.AddListener(getInputStu2);
        student3.onEndEdit.AddListener(getInputStu3);
        teacher.onEndEdit.AddListener(getInputTeacher);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Show(TeamParameters team)
    {
        teamname.text = team.Name;
        school.text = team.School;
        type.text = team.Type;
        student1.text = team.Competitors[0];
        student2.text = team.Competitors[1];
        student3.text = team.Competitors[2];
        teacher.text = team.Teacher;
    }

    public void getInputName(string text)
    {
        _name = text;
    }
    public void getInputType(string text)
    {
        _type = text;
    }
    public void getInputTeacher(string text)
    {
        _teacher = text;
    }
    public void getInputSchool(string text)
    {
        _school = text;
    }
    public void getInputStu1(string text)
    {
        _student1 = text;
    }
    public void getInputStu2(string text)
    {
        _student2 = text;
    }
    public void getInputStu3(string text)
    {
        _student3 = text;
    }

    public void Save()
    {
        TeamParameters t;
        if (_type != "")
        {
            t = new TeamParameters(_name, _school, _type, _student1, _student2, _student3, _teacher);
        }
        else
        {
            t = new TeamParameters(_name, _school, _student1, _student2, _student3, _teacher);
        }
        database.saveTeam(t);
        cancel.gameObject.SetActive(false);
        if (add.gameObject.activeSelf == false)
        {
            add.gameObject.SetActive(true);
            
        }
        this.gameObject.SetActive(false);
    }
}
