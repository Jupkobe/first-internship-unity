using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interaction : MonoBehaviour
{
    public GameObject main_cam;
    public GameObject light_bulb;
    public GameObject light_src;
    public Material light_on;
    public Material light_off;
    Animator anim;
    float range;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown("e"))
        {
            // Arranges range depends on your cam is fps or tps
            Cam script = main_cam.GetComponent<Cam>();            
            if (script.curr_cam == script.tps) range = 7f;
            else range = 4f;

            // Shoots a raycast in the cameras facing direction and if it hits to the object(in this case it's our button) calls the function "switch_light".
            RaycastHit hit;
            if (Physics.Raycast(main_cam.transform.position, main_cam.transform.forward, out hit, range))
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
        // This function activates or deactivates the light source, changes the material and plays the button animation.
        if (light_src.activeSelf)
        {
            light_src.SetActive(false);
            light_bulb.GetComponent<MeshRenderer> ().material = light_off;
            anim.Play("Button_off");
        }
        else
        {
            light_src.SetActive(true);
            light_bulb.GetComponent<MeshRenderer> ().material = light_on;
            anim.Play("Button_on");
        }
    }
}
