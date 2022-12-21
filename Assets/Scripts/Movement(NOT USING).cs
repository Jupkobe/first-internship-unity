using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Vector3 lastMouse = new Vector3(Screen.width / 2, Screen.height / 2, 0);
    public Vector3 direction;
    public Rigidbody RB;
    public GameObject ch;
    float camSens = 0.25f;
    private float movementSpeed = 5f;

    void Start()
    {
    }

    void Update()
    {
        // WASD girdilerini almamizi sagliyor.
        direction = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        
        // Kameranin yatayda donusu karakter hareketi oldugu icin mouse inputunun yatayi ile karakter rotasyonu saglaniyor.
        lastMouse = Input.mousePosition - lastMouse;
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y + (lastMouse.x * camSens), 0);
        lastMouse = Input.mousePosition;
        
    }

    void FixedUpdate()
    {
        movement(direction);
    }

    public void movement(Vector3 dir)
    {
        // Inputlar hesaplanarak karakter yonlendiriliyor.
        RB.MovePosition(transform.position + (dir.z * transform.forward + dir.x * transform.right).normalized * movementSpeed * Time.deltaTime);
        /*
        // Eger yalnizca tek bi input var ise o yonde hareket
        if (dir.x == 0)
        {
            RB.MovePosition(transform.position + (dir.z * transform.forward).normalized * movementSpeed * Time.deltaTime);
        }
        else if (dir.z == 0) 
        {
            RB.MovePosition(transform.position + (dir.x * transform.right).normalized * movementSpeed * Time.deltaTime);
        }
        else
        {
        }*/
    }
}
