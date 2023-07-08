using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lights_check : MonoBehaviour
{
    public GameObject red, white, orange;
    public bool light_check;
    private bool r, w, o;

    // Start is called before the first frame update
    void Start()
    {
        light_check = false;
        r = false;
        w = false;
        o = false;
    }

    // Update is called once per frame
    void Update()
    {
        r = red.GetComponent<Glowing>().is_ok;
        w = white.GetComponent<Glowing>().is_ok;
        o = orange.GetComponent<Glowing>().is_ok;
        if (r && w && o) {
            light_check = true;
        }
    }
}
