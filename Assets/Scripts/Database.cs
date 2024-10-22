using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Database : MonoBehaviour
{
    // datas controler
    public TextAsset teamsData;
    public List<TeamParameters> teamList = new List<TeamParameters>();
    public Dictionary<string, int> typeID = new Dictionary<string, int>();
    public GameObject prefab;
    private TeamDisplay display;
    public GameObject pool;
    public List<GameObject> poolList = new List<GameObject>();

    // page controler
    public int page = 1;
    public int cnt = 0;
    public TMP_Text cur_page;
    public Button next;
    public Button prev;
    public int changePos;

    // Start is called before the first frame update
    void Start()
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

        this.cur_page.text = this.page.ToString();
        if ((this.page - 1) * 5 + cnt >= teamList.Count + 1)
        {
            this.next.gameObject.SetActive(false);
        }
        if (this.page == 1)
        {
            this.prev.gameObject.SetActive(false);
        }

        LoadTeamData();
        //testLoad();
        //show();
        Display();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // bool listener
    private void Star()
    {
        foreach(var prefab in poolList)
        {
            TeamDisplay teamDisplay = prefab.GetComponent<TeamDisplay>();
            if(teamDisplay != null)
            {
                teamDisplay.onBoolChanged += HandlePrefabBoolChanged;
            }
        }
    }

    private void HandlePrefabBoolChanged(TeamDisplay teamDisplay, bool newValue)
    {
        if (newValue)
        {
            RemovePrefab(teamDisplay.gameObject);
        }
    }

    private void RemovePrefab(GameObject prefab)
    {
        if (poolList.Contains(prefab))
        {
            this.changePos = prefab.GetComponent<TeamDisplay>().Team.ID;
            teamList.Remove(prefab.GetComponent<TeamDisplay>().Team);
            Destroy(prefab);
            ChangeID();
            Display();
        }
    }

    private void OnDestroy()
    {
        foreach(var prefab in poolList)
        {
            TeamDisplay teamDisplay = prefab.GetComponent<TeamDisplay>();
            if (teamDisplay != null)
            {
                teamDisplay.onBoolChanged -= HandlePrefabBoolChanged;
            }
        }
    }

    // change the page
    public void nextPage()
    {
        this.page++;
        Display();
        this.cur_page.text = this.page.ToString();
        if(this.prev.gameObject.activeSelf == false)
        {
            this.prev.gameObject.SetActive(true);
        }
        if((this.page - 1) * 5 + cnt >= teamList.Count + 1)
        {
            this.next.gameObject.SetActive(false);
        }
    }

    public void prevPage()
    {
        this.page--;
        Display();
        this.cur_page.text = this.page.ToString();
        if(this.page == 1)
        {
            this.prev.gameObject.SetActive(false);
        }
        if (this.next.gameObject.activeSelf == false)
        {
            this.next.gameObject.SetActive(true);
        }
    }

    // load and display
    public void LoadTeamData()
    {
        string[] dataRow = teamsData.text.Split('\n');
        foreach(var row in dataRow)
        {
            string[] rowArray = row.Split(',');
            if (rowArray[0] == "#" || rowArray[0] == "")
            {
                continue;
            }

            int _id = int.Parse(rowArray[0]);
            string _name = rowArray[1];
            string _school = rowArray[2];
            string _type = rowArray[3];
            int _typeID = this.typeID[_type];
            string student1 = rowArray[4];
            string student2 = rowArray[5];
            string student3 = rowArray[6];
            string _teacher = rowArray[7];

            TeamParameters team = new TeamParameters(_id, _name, _school, _type, _typeID,
                student1, student2, student3, _teacher);
            saveTeam(team);
        }
    }

    private void ChangeID()
    {
        foreach(var team in teamList)
        {
            if(team.ID < this.changePos)
            {
                continue;
            }

            team.ID--;
        }
    }


    private void testLoad()
    {
        foreach(var team in this.teamList)
        {
            Debug.Log(team.ToString());
        }
    }

    public void saveTeam(TeamParameters team)
    {
        team.ID = this.teamList.Count + 1;
        this.teamList.Add(team);
        /*
        GameObject newTeam = GameObject.Instantiate(this.prefab, this.pool.transform);
        newTeam.GetComponent<TeamDisplay>().Team = team;
        poolList.Add(newTeam);
        */
        //newTeam.GetComponent<TeamDisplay>().Show(team);
    }

    public void Display()
    {
        clear();
        cnt = 0;
        /*
        foreach(var team in this.teamList)
        {
            GameObject newTeam = GameObject.Instantiate(this.prefab, this.pool.transform);
            newTeam.GetComponent<TeamDisplay>().Team = team;
            poolList.Add(newTeam);
        }*/

        for(; cnt < Mathf.Min(5, teamList.Count - (this.page - 1) * 5); ++cnt)
        {
            GameObject newTeam = GameObject.Instantiate(this.prefab, this.pool.transform);
            newTeam.GetComponent<TeamDisplay>().Team = this.teamList[(this.page - 1) * 5 + cnt];
            poolList.Add(newTeam);
            TeamDisplay teamDisplay = newTeam.GetComponent<TeamDisplay>();
            if (teamDisplay != null)
            {
                teamDisplay.onBoolChanged += HandlePrefabBoolChanged;
            }
        }
    }

    public void clear()
    {
        foreach(var item in poolList)
        {
            Destroy(item);
        }
        poolList.Clear();
    }
}
