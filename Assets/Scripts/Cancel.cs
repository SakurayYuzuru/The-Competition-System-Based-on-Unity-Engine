using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cancel : MonoBehaviour
{
    public GameObject input;
    public Button save;
    public Button add;
    public Button edit;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        input.gameObject.SetActive(false);
        save.gameObject.SetActive(false);
        add.gameObject.SetActive(true);
        edit.gameObject.SetActive(true);
        this.gameObject.SetActive(false);
    }
}