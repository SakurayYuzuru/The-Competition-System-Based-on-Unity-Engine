using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class add : MonoBehaviour
{
    public GameObject input;
    public Button cancel;
    public Button save;

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
        save.gameObject.SetActive(true);
        cancel.gameObject.SetActive(true);
        input.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
