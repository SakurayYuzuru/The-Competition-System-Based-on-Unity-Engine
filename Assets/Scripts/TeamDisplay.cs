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
    public TMP_InputField id;
    public TMP_InputField name;
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

    // edit listener
    public void OnEditClick()
    {
        name.text = Name.text;
        school.text = School.text;
        type.text = Type.text;
        student1.text = Student1.text;
        student2.text = Student2.text;
        student3.text = Student3.text;
        teacher.text = Teacher.text;

        input.SetActive(true);
        this.edit.gameObject.SetActive(false);
    }



    // delete listener
    public bool Delete => isDelete;

    private void OnButtonClicked()
    {
        isDelete = !isDelete;
        onBoolChanged?.Invoke(this, isDelete);
    }

    private void OnDestroy()
    {
        if(delete != null)
        {
            delete.onClick.RemoveListener(OnButtonClicked);
        }
    }
}
