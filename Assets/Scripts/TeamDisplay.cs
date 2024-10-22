using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
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

    public TeamParameters Team = new TeamParameters();

    // Start is called before the first frame update
    void Start()
    {
        Show(this.Team);
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
}
