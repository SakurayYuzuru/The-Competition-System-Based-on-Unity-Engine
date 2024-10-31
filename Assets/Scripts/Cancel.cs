using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cancel : MonoBehaviour
{
    public GameObject input;
    public Button add;
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
        input.gameObject.SetActive(false);
        add.gameObject.SetActive(true);
        save.gameObject.SetActive(false);
        this.gameObject.SetActive(false);
    }
}
