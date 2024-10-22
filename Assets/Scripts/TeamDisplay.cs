using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
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
    public Button delete;

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
