using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public GameObject button;

    void OnTriggerEnter(Collider collider)
    {
        button.GetComponent<Interaction>().switch_light();
    }
}
