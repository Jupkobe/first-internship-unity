using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Glowing : MonoBehaviour
{
    public Camera cam;
    public bool is_ok, is_on;

    // Start is called before the first frame update
    void Start()
    {
        is_ok = false;
        is_on = false;
    }

    // Update is called once per frame
    void Update()
    {   // Shoots a ray to detect the objects which this script binded and makes them glow
        if(Physics.Raycast(cam.transform.position, cam.transform.forward, out RaycastHit hit, 5)){
            if(hit.transform.gameObject == gameObject) {
                gameObject.GetComponent<Outline>().enabled = true;
                is_ok = true;
                is_on = true;
            }
            else {
                gameObject.GetComponent<Outline>().enabled = false;
                is_on = false;
            }
        }
        else {
            gameObject.GetComponent<Outline>().enabled = false;
            is_on = false;
        }
    }
}
