using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class pressure_panel : MonoBehaviour
{
    public bool is_on, is_ok, isHolding;
    public int psi;
    public GameObject panel, text, compressor;
    TextMeshProUGUI textMeshProUGUI;
    bool is_connected;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GameObject.Find("EGEROBOT_Worker").GetComponent<Animator>();
        is_on = false; // is looking at?
        textMeshProUGUI = text.GetComponent<TextMeshProUGUI>();
        is_ok = false;
        is_connected = false;
    }

    void Pump() {
        if(psi < 100) {
            psi += 1; // Increases the value
            textMeshProUGUI.text = psi.ToString(); // Prints the value
            // Panel configuration
            if (psi < 100) {
                textMeshProUGUI.color = Color.yellow;
                is_ok = false;
            }
            else {
                textMeshProUGUI.color = Color.green;
                is_ok = true;
            }
            timerReached = false;
        }
    }

    // We set a timer to increase the values slowly
    float timer = 0f;
    bool timerReached = false;    
    void Update()
    {        
        isHolding = compressor.GetComponent<HoldCompressor>().isHolding;    
        // Panel configuration
        if(is_on) { // Enables the panel
            panel.SetActive(true);
            textMeshProUGUI.text = psi.ToString();
            if (psi < 100) {
                textMeshProUGUI.color = Color.yellow;
                is_ok = false;
            }
            else {
                textMeshProUGUI.color = Color.green;
                is_ok = true;
            }
        }
        else if (!is_connected) {
            panel.SetActive(false);
        }
        if (isHolding && is_connected){ // if the pump is connected...
            panel.SetActive(true);
            if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.4f)
                {
                    animator.speed = 0; // ...pause the animation...
                }
            if (!timerReached) 
                timer += Time.deltaTime;

            if (!timerReached && timer > .25f){ 
                // ...and call the function that increases the value
                timerReached = true;
                timer = 0;
                Pump();
            }
        }
        if(is_ok && is_connected){ 
            // Resumes the animation if the value reaches the limit
            animator.speed = 1;
        }
    }

    // Checking if the pump is connected
    void OnTriggerEnter(Collider c) {
        if (c.gameObject == compressor){
            is_connected = true;
        }        
    }

    void OnTriggerExit(Collider c) {        
        if (c.gameObject == compressor){
            is_connected = false;
        }      
    }
}
