using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    public Camera main_cam;
    public GameObject skin;
    public GameObject fps;
    public GameObject tps;
    public Material transparent;
    public Material body_mat;
    GameObject curr_cam;
    SkinnedMeshRenderer skinRenderer;
    Material[] mats;


    void Start()
    {
        curr_cam = tps;
        skinRenderer = skin.GetComponent<SkinnedMeshRenderer>();
        mats = skinRenderer.materials;
    }

    void Update()
    {
        if (Input.GetKeyDown("v")) // Switches between cameras on key "v" press
        {
            change_cam();
        }
    }

    void change_cam()
    {
        // Switches between cameras and makes characters head invisible.
        if (curr_cam == tps)
        {
            // Enables the current camera and disabled the other(s).
            tps.SetActive(false);
            fps.SetActive(true);

            // Changes worker's body material to transparent one to make it invisible in fps mode.
            mats[0] = transparent;
            skinRenderer.materials = mats;

            curr_cam = fps;
        }
        else
        {
            // Enables the current camera and disabled the other(s).
            tps.SetActive(true);
            fps.SetActive(false);

            // Changes worker's body material to original one back to make it visible in tps mode.
            mats[0] = body_mat;
            skinRenderer.materials = mats;

            curr_cam = tps;
        }
    }
}
