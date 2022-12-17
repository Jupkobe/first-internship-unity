using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    private Vector3 eulerAngles = new Vector3(Screen.width / 2, Screen.height / 2, 0);
    float camSens = 2.5f;
    public GameObject fps;
    public GameObject tps;
    public GameObject curr_cam;
    public float minAngle;
    public float maxAngle;
    float xAngle = 0;


    void Start()
    {
        curr_cam = tps;
    }

    void Update()
    {
        // Calculates the camera rotation via mouse movements
        float mouseX = Input.GetAxis("Mouse Y");
        xAngle += -mouseX * camSens;
        xAngle = Mathf.Clamp(xAngle, minAngle, maxAngle);
        transform.eulerAngles = new Vector3(xAngle, transform.eulerAngles.y, 0);

        if (Input.GetKeyDown("v")) // Kamera degistirme
        {
            if (curr_cam == tps)
            { 
                minAngle = -90;
                maxAngle = 90;
                tps.SetActive(false);
                fps.SetActive(true);
                curr_cam = fps;
            }
            else
            {
                minAngle = -45;
                maxAngle = 45;
                fps.SetActive(false);
                tps.SetActive(true);
                curr_cam = tps;
            }
        }
    }
}
