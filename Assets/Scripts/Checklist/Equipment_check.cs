using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Equipment_check : MonoBehaviour
{
    public GameObject glasses, helmet, gloves;
    public bool eq_check;

    // Start is called before the first frame update
    void Start()
    {
        eq_check = false;        
    }

    // Update is called once per frame
    void Update()
    {
        if(glasses.activeSelf && helmet.activeSelf && gloves.activeSelf){
            eq_check = true;
        }

    }
}
