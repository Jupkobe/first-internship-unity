using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    public Camera main_cam;
    public GameObject fps;
    public GameObject tps;
    public GameObject curr_cam;


    void Start()
    {
        curr_cam = tps;
    }

    void Update()
    {
        if (Input.GetKeyDown("v")) // Switches between cameras on key "v" click
        {
            change_cam();
        }
    }

    void change_cam()
    {
        // Switches between cameras and changes culling mask of main camera.
        if (curr_cam == tps)
        {
            tps.SetActive(false);
            fps.SetActive(true);
            main_cam.cullingMask = 63; // Makes player invisible in fps mode
            curr_cam = fps;
        }
        else
        {
            tps.SetActive(true);
            fps.SetActive(false);
            main_cam.cullingMask = 127; // Makes player visible in tps mode
            curr_cam = tps;
        }
    }
}
