using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : MonoBehaviour
{
    public GameObject helmet, gloves, glasses;


    void OnCollisionEnter(Collision c)
    {   //Enables unactive equipments on collision
        if (c.gameObject.name == "Gloves"){
            c.gameObject.SetActive(false);
            gloves.SetActive(true);
        }
        else if (c.gameObject.name == "Helmet"){            
            c.gameObject.SetActive(false);
            helmet.SetActive(true);
        }
        else if (c.gameObject.name == "Glasses"){            
            c.gameObject.SetActive(false);
            glasses.SetActive(true);
        }
    }
}
