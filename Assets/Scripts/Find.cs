using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Find : MonoBehaviour
{
    public Database database;
    public TMP_InputField input;
    public TMP_Dropdown dropdown;
    public Button search;
    public GameObject prefab;

    // Start is called before the first frame update
    void Start()
    {
        dropdown.onValueChanged.AddListener(delegate { DropdownValueChanged(dropdown); });
        search.onClick.AddListener(OnButtonValueChanged);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnButtonValueChanged()
    {
        switch (dropdown.value)
        {
            case 0:
                database.Display();
                break;
            case 1:
                input.onValueChanged.AddListener(OnInputValueChangedInteger);
                findID(int.Parse(input.text));
                break;
            case 2:
                input.onValueChanged.AddListener(OnInputValueChangedString);
                findSchool(input.text);
                break;
        }
    }

    private void DropdownValueChanged(TMP_Dropdown change)
    {
        Debug.Log("New value: " + change.value);  // 输出选中的选项索引
    }

    private void findID(int _id)
    {
        database.clear();
        database.page = 1;
        foreach (var team in database.teamList)
        {
            Debug.Log(team.ToString());
            database.showList.Clear();
            if (team.ID == _id)
            {
                GameObject newTeam = GameObject.Instantiate(this.prefab, database.pool.transform);
                newTeam.GetComponent<TeamDisplay>().Team = team;
                database.poolList.Add(newTeam);
                database.showList.Add(team);
                database.isDelete(newTeam);
                return;
            }
        }
    }

    private void findSchool(string _school)
    {

    }

    private void OnInputValueChangedInteger(string input)
    {
        string pattern = "^[0-9]*$";
        if(!Regex.IsMatch(input, pattern))
        {
            char item = input[input.Length - 1];
            this.input.text.Remove(item);
        }
    }

    private void OnInputValueChangedString(string input)
    {
        string pattern = "^[A-Z]*$";
        if (!Regex.IsMatch(input, pattern))
        {
            char item = input[input.Length - 1];
            this.input.text.Remove(item);
        }
    }
}
