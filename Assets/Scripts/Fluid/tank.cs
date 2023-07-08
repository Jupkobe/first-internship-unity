using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tank : MonoBehaviour
{
    public GameObject tank_f, tank_h;
    public bool isHolding;
    // Start is called before the first frame update
    void Start()
    {
        isHolding = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider c){
        if (c.gameObject.name == "Right_Hand"){
            tank_f.SetActive(isHolding);
            tank_h.SetActive(!isHolding);
            isHolding = !isHolding;
        }
    }
}
