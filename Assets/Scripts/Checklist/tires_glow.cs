using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tires_glow : MonoBehaviour
{
    public Camera cam;
    pressure_panel sc;

    // Start is called before the first frame update
    void Start()
    {
        sc = gameObject.GetComponent<pressure_panel>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Physics.Raycast(cam.transform.position, cam.transform.forward, out RaycastHit hit, 5)){
            // Debug.Log(hit.collider.gameObject.name);
            if(hit.transform.gameObject == gameObject) {
                gameObject.GetComponent<Outline>().enabled = true;
                sc.is_on = true;
            }
            else {
                gameObject.GetComponent<Outline>().enabled = false;
                sc.is_on = false;
            }
        }
        else {
            gameObject.GetComponent<Outline>().enabled = false;
            sc.is_on = false;
        }
    }
}
