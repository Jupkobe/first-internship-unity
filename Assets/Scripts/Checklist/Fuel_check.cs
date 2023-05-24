using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fuel_check : MonoBehaviour
{
    public GameObject tank;
    public bool fuel_check;

    // Start is called before the first frame update
    void Start()
    {
        fuel_check = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(tank.GetComponent<fuel>().is_ok){
            fuel_check = true;
            /*GameObject f = GameObject.Find("fuel");
            f.GetComponent<Toggle>().isOn = true;*/
        }
        else {
            fuel_check = false;
            /*GameObject f = GameObject.Find("fuel");
            f.GetComponent<Toggle>().isOn = false;   */  
        }
    }
}
