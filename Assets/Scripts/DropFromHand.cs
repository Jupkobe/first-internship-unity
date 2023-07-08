using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropFromHand : MonoBehaviour
{
    public GameObject Gun, Charger;
    HoldCompressor hcomp;
    HoldCharger hcharger;

    // Start is called before the first frame update
    void Start()
    {
        hcomp = Gun.GetComponent<HoldCompressor>();
        hcharger = Charger.GetComponent<HoldCharger>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider c){
        if (c.gameObject.name == "Right_Hand"){
            if (hcomp.isHolding) {
                hcomp.isHolding = false;
            }
            else if (hcharger.isHolding) {                
                hcharger.isHolding = false;
            }
        }
    }
}
