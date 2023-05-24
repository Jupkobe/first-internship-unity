using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Check_check : MonoBehaviour
{
    public GameObject cong, p1, p2, p3, p4;
    bool a, b, c, d;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        a = gameObject.GetComponent<Equipment_check>().eq_check;
        b = gameObject.GetComponent<Tires_check>().tire_check;
        c = gameObject.GetComponent<Fuel_check>().fuel_check;
        d = gameObject.GetComponent<Lights_check>().light_check;
        if(a){
            p1.SetActive(false);
            p2.SetActive(true);
        }
        if(b){
            p2.SetActive(false);
            p3.SetActive(true);
        }
        if(c){            
            p3.SetActive(false);
            p4.SetActive(true);
        }
        if (d){
            p4.SetActive(false);
            cong.SetActive(true);
        }        
    }
}
