using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class idChec : MonoBehaviour
{
    public Database database;
    public GameObject input;
    public int ID;

    void Start()
    {
        // 可以在Start中调用checked方法
    }

    // Update is called once per frame
    void Update()
    {

    }

    void checkedID()
    {
        TeamParameters sreachTeam = find(ID);
        if (sreachTeam != null)
        {
            Debug.Log("Team found: " + sreachTeam.ToString());
        }
        else
        {
            Debug.Log("Team not found.");
        }
    }

    TeamParameters find(int index)
    {
        
        return null; // 如果没有找到，返回null
    }
}