using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Edit : MonoBehaviour
{
    public GameObject input;
    public Button add;
    public Button cancel;

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
        input.SetActive(true);
        cancel.gameObject.SetActive(true);
        add.gameObject.SetActive(false);
        this.gameObject.SetActive(false);
    }
}
