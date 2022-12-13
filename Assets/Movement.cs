using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody RB;
    public GameObject ch;
    public GameObject fps;
    public GameObject tps;
    private float movementSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("w"))
        {
            transform.position += new Vector3(0, 0, movementSpeed * Time.deltaTime);
        }
        if (Input.GetKey("s"))
        {
            transform.position += new Vector3(0, 0, -movementSpeed * Time.deltaTime);
        }
        if (Input.GetKey("d"))
        {
            transform.position += new Vector3(movementSpeed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey("a"))
        {
            transform.position += new Vector3(-movementSpeed * Time.deltaTime, 0, 0);
        }

        if (Input.GetKeyDown("c"))
        {
            switch_camera();
        }
    }

    public void switch_camera()
    {
        fps.SetActive(!fps.activeSelf);
        tps.SetActive(!tps.activeSelf);
    }
}
