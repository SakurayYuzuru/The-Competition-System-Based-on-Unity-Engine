using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TeamDisplay : MonoBehaviour
{
    // display text
    public TMP_Text ID;
    public TMP_Text Name;
    public TMP_Text School;
    public TMP_Text Type;
    public TMP_Text Student1, Student2, Student3;
    public TMP_Text Teacher;
    public Button delete;

    // edit input field
    public GameObject input;
    public TMP_InputField _name;
    public TMP_InputField school;
    public TMP_InputField type;
    public TMP_InputField student1, student2, student3;
    public TMP_InputField teacher;
    public Button save;
    public Button edit;

    public TeamParameters Team = new TeamParameters();

    // bool listener
    public bool isDelete = false;
    public event Action<TeamDisplay, bool> onBoolChanged;

    // Start is called before the first frame update
    void Start()
    {
        Show(this.Team);
        if(delete != null)
        {
            delete.onClick.AddListener(OnButtonClicked);
        }
        if(edit != null)
        {
            edit.onClick.AddListener(OnEditClick);
        }
        input.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Show(TeamParameters Team)
    {
        ID.text = Team.ID.ToString();
        Name.text = Team.Name;
        School.text = Team.School;
        Type.text = Team.Type;
        Student1.text = Team.Competitors[0];
        Student2.text = Team.Competitors[1];
        Student3.text = Team.Competitors[2];
        Teacher.text = Team.Teacher;
    }

    private void invShow()
    {
        Team = new TeamParameters(int.Parse(ID.text), Name.text, School.text, Type.text, 
            Student1.text, Student2.text, Student3.text, Teacher.text);
    }

    // edit listener
    public void OnSaveClick()
    {
        _name.onEndEdit.RemoveAllListeners();
        school.onEndEdit.RemoveAllListeners();
        type.onEndEdit.RemoveAllListeners();
        student1.onEndEdit.RemoveAllListeners();
        student2.onEndEdit.RemoveAllListeners();
        student3.onEndEdit.RemoveAllListeners();
        teacher.onEndEdit.RemoveAllListeners();

        // TODO: send data to database
        Database.Instance.UpdateTeam(Team);

        this.edit.gameObject.SetActive(true);
        this.delete.gameObject.SetActive(true);
        this.input.gameObject.SetActive(false);
    }

    public void OnEditClick()
    {
        this.delete.gameObject.SetActive(false);
        this.edit.gameObject.SetActive(false);
        input.SetActive(true);
        
        _name.onEndEdit.AddListener(getInputName);
        school.onEndEdit.AddListener(getInputSchool);
        type.onEndEdit.AddListener(getInputType);
        student1.onEndEdit.AddListener(getInputStu1);
        student2.onEndEdit.AddListener(getInputStu2);
        student3.onEndEdit.AddListener(getInputStu3);
        teacher.onEndEdit.AddListener(getInputTeacher);
        this.save.onClick.AddListener(OnSaveClick);

        invShow();
    }

    public void getInputID(string text)
    {
        ID.text = text;
        Team.ID = int.Parse(ID.text);
    }

    public void getInputName(string text)
    {
        Name.text = text;
        Team.Name = text;
    }
    public void getInputType(string text)
    {
        Type.text = text;
        Team.Type = text;
        Team.typeid = Team.typeID[Team.Type];
    }
    public void getInputTeacher(string text)
    {
        Teacher.text = text;
        Team.Teacher = text;
    }
    public void getInputSchool(string text)
    {
        School.text = text;
        Team.School = text;
    }
    public void getInputStu1(string text)
    {
        Student1.text = text;
        Team.Competitors[0] = text;
    }
    public void getInputStu2(string text)
    {
        Student2.text = text;
        Team.Competitors[1] = text;
    }
    public void getInputStu3(string text)
    {
        Student3.text = text;
        Team.Competitors[2] = text;
    }

    // delete
    private void OnButtonClicked()
    {
        Database.Instance.DeleteTeam(Team);
    }
}
