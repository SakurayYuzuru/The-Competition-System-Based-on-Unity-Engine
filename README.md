# The Competition System Based on Unity Engine
This project is fully open-sourced on GitHub.  
https://github.com/SakurayYuzuru/The-Competition-System-Based-on-Unity-Engine
## Load and Save
Unity support TextAssets to load csv file and `C#` support `string.Split(char)` to split text.  
We could also use StreamWriter in `System.IO` to write text into a file.
```csharp
public class Database{
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
    public void Save(string filepath)
    {
        loadData();
        using(StreamWriter writer = new StreamWriter(filepath))
        {
            writer.WriteLine("#,Name,School,Type,Competitors,,,Teacher");
            foreach (string row in data)
            {
                writer.WriteLine(string.Join("\n", row));
            }
        }

        //Debug.Log("saved as: " +  filepath);
    }
}
```

## Manage competition teams attributes
```csharp
public class TeamParameters{
    // Competitors'id
    public int ID;   
    // Name of the competition entry  
    public string Name;
    // school name
    public string School; 
    // Competition type
    public string Type;
    // type id
    public int typeid;
    // Competitors' names
    // include from student1 to student3
    public string[] Competitors = new string[3];    
    // Teacher
    public string Teacher;
}
```  
We choose `typeid` as the serial number of the competition category, and build `Dictionary<string, int> typeID` to memory these serial numbers.  
To help build this dictionary, I push a enumerate class to write.  
```csharp{global.cs}
public enum TypeID
{
    // Cpp Programming
    Cpp = 1,
    // Java Software Develpment
    Java = 2,
    // Python Programming
    Python = 3,
    // Web Application Development
    Web = 4,
    // Network Security
    Network = 5,
    // Embedded Design and Development
    Embedded = 6,
    // 
    Microcontroller = 7,
    EDA = 8,
    IoT = 9,
    FPGA = 10,
    fiveG = 11
}
```  
And you must use my standard(the form in the comments) input to get the typeid you want.  

We also build a database for process data, like add, delete, edit, sort and find. These will be introduced in the later sections.

## Add
We use Button(TMP, which is in UnityEngine.UI and TMPro) to help user select `add` function, which bind with `GameObject input` and other functions.  
When you click on the button "add", the button "cancel" will be disappeared ,"save" and the GameObject, maybe I should say component "input" will appears.  
In the scripts "getInput.cs", we use TMP_InputField to get user's input. In this part, we use the design pattern: Observer pattern. It listens for changes in the values of the child component by listener.
```csharp
public class getInput{
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
}
```  
To load the value into database, we manege database by using singleton pattern.
```csharp
public class Database{
    public static Database Instance { 
        get; private set; 
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
```  
Therefore, we could call database in anywhere we want.
```csharp{Database.class}
public class Database{
    public void saveTeam(TeamParameters team)
    {
        team.ID = this.teamList.Count + 1;
        this.teamList.Add(team);
    }
}
```
```csharp{getInput.cs}
public class getInput{
    public void Save()
    {
        TeamParameters t = 
        new TeamParameters(_name, _school, _type, 
        _student1, _student2, _student3,
         _teacher);
        Database.Instance.saveTeam(t);
        cancel.gameObject.SetActive(false);
        if (add.gameObject.activeSelf == false)
        {
            add.gameObject.SetActive(true);
            
        }
        this.save.gameObject.SetActive(false);
        this.add.gameObject.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
```  
The function `saveTeam()` is a public method for loading and adding. Because we store data too frequently, we have written it as a public method.

## Delete
We want to listen the change from another GameObjects' component. The delete button is the content of prefab, and we couldn't access it between prefab and non-prefab. As the database is dynamic, we couldn't make it as a prefab. In the end, we only have two solutions: observer pattern, and singleton pattern.  
At first, we choose observer pattern as our solution to make the object destroied and remove from `database.teamList` and `database.showList`. 
```csharp
public class Database{
    private void Star()
    {
        foreach(var prefab in poolList)
        {
            TeamDisplay teamDisplay = 
            prefab.GetComponent<TeamDisplay>();
            if(teamDisplay != null)
            {
                teamDisplay.onBoolChanged += 
                HandlePrefabBoolChanged;
            }
        }
    }

    public void isDelete(GameObject newTeam)
    {
        TeamDisplay teamDisplay = 
        newTeam.GetComponent<TeamDisplay>();
        if (teamDisplay != null)
        {
            teamDisplay.onBoolChanged += 
            HandlePrefabBoolChanged;
        }
    }

    private void HandlePrefabBoolChanged
    (TeamDisplay teamDisplay, bool newValue)
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
            this.changePos = 
            prefab.GetComponent<TeamDisplay>().Team.ID;
            teamList.Remove(prefab.GetComponent<TeamDisplay>().Team);
            showList.Remove(prefab.GetComponent<TeamDisplay>().Team);
            Destroy(prefab);
            ChangeID();
            cnt = Mathf.Min(5, this.teamList.Count);
            if ((this.page - 1) * 5 + cnt >= showList.Count)
            {
                this.next.gameObject.SetActive(false);
                this.page--;
                this.cur_page.text = this.page.ToString();
            }
            if (this.page == 1)
            {
                this.prev.gameObject.SetActive(false);
            }
            Display();
            //Debug.Log(teamList.Count.ToString() + " " + showList.Count.ToString() + " " + cnt.ToString());
            if ((this.page - 1) * 5 + cnt >= teamList.Count)
            {
                this.next.gameObject.SetActive(false);
            }
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
}
```
But finally, we did it with singleton pattern to avoid conflicts, as I am not sure why I encounter issues when using these two design patterns at the same time.
```csharp
public class Database{
    public void 
    DeleteTeam(TeamParameters deleteTeam)
    {
        for(int i = 0; i < teamList.Count; ++i)
        {
            if (teamList[i] == deleteTeam)
            {
                teamList.RemoveAt(i);
                break;
            }
        }
        for (int i = 0; i < showList.Count; ++i)
        {
            if (showList[i] == deleteTeam)
            {
                showList.RemoveAt(i);
                break;
            }
        }
        Display();
    }
}
```
```csharp
public class TeamDisplay{
    void Start()
    {
        Show(this.Team);
        if(delete != null)
        {
            delete.onClick.AddListener(OnButtonClicked);
        }
    }
    private void OnButtonClicked()
    {
        Database.Instance.DeleteTeam(Team);
    }
}
```

## Edit
If you use cmd or other shell to open the systems with the same underlying principles, "edit" may not be the most difficult thing. But in GUI development, we have to think of how we edit the value of team and how to load it.  
After we completed the page display, we found only use observer pattern was too difficult to solve it. Then, we combinded with singleton pattern.  
```csharp
public class TeamDisplay{
    void Start()
    {
        if(edit != null)
        {
            edit.onClick.AddListener(OnEditClick);
        }
        input.gameObject.SetActive(false);
    }

    private void invShow()
    {
        Team = 
        new TeamParameters(int.Parse(ID.text), 
        Name.text, School.text, Type.text, 
        Student1.text, Student2.text, 
        Student3.text, Teacher.text);
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
}
```
```csharp
public class Database{
    public void UpdateTeam(TeamParameters updatedTeam)
    {
        for (int i = 0; i < teamList.Count; i++)
        {
            if (teamList[i].ID == updatedTeam.ID)
            {
                teamList[i] = updatedTeam;
                break;
            }
        }
        for (int i = 0; i < showList.Count; ++i)
        {
            if (showList[i].ID == updatedTeam.ID)
            {
                showList[i] = updatedTeam;
                break;
            }
        }
        Display();
    }
}
```

## Search
Because there are two demands of searching, we choose to use TMP_Dropdown to handle different situations. In this section, we also use the observe pattern.
```csharp
public class Database{
    private void OnButtonValueChanged()
    {
        switch (this.dropdown.value)
        {
            case 0:
                showList = teamList;
                Display();
                break;
            case 1:
                input.onValueChanged.AddListener(OnInputValueChangedInteger);
                Debug.Log(input.text);
                showList = findID(input.text);
                sortSchool();
                Display();
                break;
            case 2:
                input.onValueChanged.AddListener(OnInputValueChangedString);
                showList = findSchool(input.text);
                sortTypeID();
                Display();
                break;
        }
    }
}
```
### Through ID
Firstly, we hope it could display the value directly. But the actual results are not satisfactory. So we choose the same solution as search with typeID.
```csharp
public class Database{
    private List<TeamParameters> findID(string text)
    {
        List<TeamParameters> list = new List<TeamParameters> ();
        clear();
        page = 1;
        int _id = int.Parse(text);

        testLoad();
        foreach (var team in teamList)
        {
            Debug.Log("team");
            if (team.ID == _id)
            {
                list.Add(team);
            }
        }

        return list;
    }
}
```

### Through Type
As we know, sorting string is based on character's hash value, so we must memorize it into an integer.
So in our ADT, you can see there has a int value to memory the type.  
```csharp
public class Database{
    private List<TeamParameters> findSchool(string _school)
    {
        List<TeamParameters > list = new List<TeamParameters>();
        foreach(var team in teamList)
        {
            if(team.School == _school)
            {
                list.Add(team);
            }
        }

        return list;
    }

    private void sortTypeID()
    {
        showList.Sort((x, y) => 
        x.typeid.CompareTo(y.typeid));
    }
}
```

## Other features
### Page changer
We support you could see 5 teams on your screen at the same time. You could click on `pre page` or `next page` to change the page. It also support in searching.  

### Sort with school
In our system, the school name is abbreviated. If there are many teams here, you may feel troubled due to the chaos. So we sort these teams by school name.

### Exit
An application must have a exit button. We support you click on `Exit` button to close this process.

## Future Work
Our searching algorithm could use other datastructure like `multi_map<T, T>` in cpp which support O(1) searching.