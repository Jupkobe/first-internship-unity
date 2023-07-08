using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fork_check : MonoBehaviour
{
    public GameObject fork;
    public bool fork_check;
    private bool f;

    // Start is called before the first frame update
    void Start()
    {
        fork_check = false;
        f = false;
    }

    // Update is called once per frame
    void Update()
    {
        f = fork.GetComponent<Glowing>().is_ok;
        if (f) {
            GameObject fo = GameObject.Find("fork");
            fo.GetComponent<Toggle>().isOn = true;
            fork_check = true;
        }
    }
}