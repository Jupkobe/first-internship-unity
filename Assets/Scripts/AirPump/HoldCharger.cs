using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldCharger : MonoBehaviour
{
    public Camera cam;
    public GameObject objectToHold, fuel;
    public Transform holdPosition, starting_position, charge_pos;
    public bool isHolding, is_on, charging;

    // Start is called before the first frame update
    void Start()
    {
        isHolding = false;
        charging = false;
        is_on = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Physics.Raycast(cam.transform.position, cam.transform.forward, out RaycastHit hit, 5)){
            // Debug.Log(hit.collider.gameObject.name);
            if(hit.transform.gameObject == gameObject) {
                gameObject.GetComponent<Outline>().enabled = true;
                is_on = true;
            }
            else {
                gameObject.GetComponent<Outline>().enabled = false;
                is_on = false;
            }
        }
        if (Input.GetKeyDown("f")) {
            isHolding = false;
        }
        if (isHolding) {
            transform.SetParent(holdPosition);
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.Euler(0f, 180f, 180f);
            transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        }
        else if (charging) {
            transform.SetParent(charge_pos);            
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.Euler(0f, 0f, 90f);
            transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        }
        else {
            transform.SetParent(starting_position);
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.Euler(180f, 180f, 180f);
            transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        }
    }

    void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.name == "Right_Hand" && !fuel.GetComponent<fuel>().is_ok && !charging) {
            isHolding = true;
        }        
        else if (c.gameObject.name == "Right_Hand" && fuel.GetComponent<fuel>().is_ok){
            isHolding = true;
            charging = false;
            fuel.GetComponent<fuel>().is_connected = false;
        }
    }
}
