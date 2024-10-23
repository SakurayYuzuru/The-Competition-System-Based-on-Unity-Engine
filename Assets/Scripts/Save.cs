using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Save : MonoBehaviour
{
    public getInput input;
    public Database database;
    public TMP_Dropdown dropdown;
    public Button save;

    // Start is called before the first frame update
    void Start()
    {
        this.dropdown.onValueChanged.AddListener(delegate { DropdownValueChanged(dropdown); });
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        if (input.gameObject.activeSelf)
        {
            input.Save();
        }
        database.Display();
    }

    private void OnButtonValueChanged()
    {
        if (this.dropdown.value == 0)
        {
            database.showList = database.teamList;
            database.Display();
        }
    }

    private void DropdownValueChanged(TMP_Dropdown change)
    {
        Debug.Log("New value: " + change.value);  // 输出选中的选项索引
        this.save.onClick.AddListener(OnButtonValueChanged);
    }
}
