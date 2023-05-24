using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pressure : MonoBehaviour
{
    GameObject a;
    // Start is called before the first frame update
    void Start()
    {
        Physics.IgnoreCollision(transform.parent.parent.GetComponent<Collider>(), GetComponent<Collider>());        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
