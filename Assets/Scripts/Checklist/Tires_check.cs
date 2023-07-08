using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tires_check : MonoBehaviour
{
    public GameObject fl, fr, rl, rr;
    public bool tire_check;

    // Start is called before the first frame update
    void Start()
    {
        tire_check = false;        
    }

    // Update is called once per frame
    void Update()
    {
        bool fl_b, fr_b, rl_b, rr_b;
        fl_b = fl.GetComponent<pressure_panel>().is_ok;
        fr_b = fr.GetComponent<pressure_panel>().is_ok;
        rl_b = rl.GetComponent<pressure_panel>().is_ok;
        rr_b = rr.GetComponent<pressure_panel>().is_ok;
        if(fl_b && fr_b && rl_b && rr_b){
            tire_check = true;
            /*GameObject tire = GameObject.Find("tires");
            tire.GetComponent<Toggle>().isOn = true;*/
        }
        else {
            tire_check = false;
            /*GameObject tire = GameObject.Find("tires");
            tire.GetComponent<Toggle>().isOn = false;    */ 
        }
    }
}
