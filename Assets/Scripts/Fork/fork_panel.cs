using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fork_panel : MonoBehaviour
{
    public GameObject panel;
    public bool is_on; 

    // Start is called before the first frame update
    void Start()
    {
        is_on = false;
    }

    // Update is called once per frame
    void Update()
    {
        is_on = gameObject.GetComponent<Glowing>().is_on;
        if(is_on){
            panel.SetActive(true);
        }
        else {
            panel.SetActive(false);
        }
        
    }
}
