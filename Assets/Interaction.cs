using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    public GameObject cam;
    public GameObject light_bulb;
    public GameObject light_src;
    public Material light_on;
    public Material light_off;

    void Start()
    {
    }

    void Update()
    {
        if (Input.GetKeyDown("e"))
        {
            Vector3 cameraForward = cam.transform.forward;

            // Raycast in the direction of the camera's forward vector
            RaycastHit hit;
            if (Physics.Raycast(cam.transform.position, cameraForward, out hit))
            {
                if (hit.transform.gameObject == gameObject)
                {
                    switch_light();   
                }
            }
        }
    }

    void switch_light()
    {
        if (light_src.activeSelf)
        {
            light_src.SetActive(false);
            light_bulb.GetComponent<MeshRenderer> ().material = light_off;
        }
        else
        {
            light_src.SetActive(true);
            light_bulb.GetComponent<MeshRenderer> ().material = light_on;
        }
    }
}
