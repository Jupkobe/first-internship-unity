using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interaction : MonoBehaviour
{
    public GameObject light_bulb;
    public GameObject light_src;
    public Material light_on;
    public Material light_off;
    public GameObject Box;
    public GameObject Trigger;
    public bool is_triggered;
    Vector3 curr_pos;
    public Rigidbody rb;

    void Start()
    {
        curr_pos = transform.position;
        Physics.IgnoreCollision(Box.GetComponent<Collider>(), GetComponent<Collider>()); // To ignore the box where button stands. Worker should collide but button shouldn't with it
                                                                                         // so only ignoring collision between the box and the button.
    }

    void FixedUpdate()
    {
        float y_pos = Mathf.Clamp(transform.position.y + Time.deltaTime * 0.75f, 0, curr_pos.y);    // Calculates and limits button's min/max position in y-axis.
        rb.MovePosition(new Vector3(transform.position.x, y_pos, transform.position.z));            // Fixes button's position after worker's push.
    }

    public void switch_light()
    {
        // This function activates or deactivates the light source and changes the material.
        if (light_src.activeSelf)
        {
            light_src.SetActive(false);
            light_bulb.GetComponent<MeshRenderer>().material = light_off;
        }
        else
        {
            light_src.SetActive(true);
            light_bulb.GetComponent<MeshRenderer>().material = light_on;
        }
    }
}
