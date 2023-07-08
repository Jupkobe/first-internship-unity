using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class fuel : MonoBehaviour
{
    public int curr_fuel;
    public bool is_on, is_ok, is_connected, isHolding;
    Animator animator;
    public GameObject panel, tank;
    public GameObject text;
    public Transform charge_pos, hand_pos;
    TextMeshProUGUI textMeshProUGUI;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GameObject.Find("EGEROBOT_Worker").GetComponent<Animator>();
        is_on = false;
        is_connected = false;
        textMeshProUGUI = text.GetComponent<TextMeshProUGUI>();
        textMeshProUGUI.text = curr_fuel.ToString() + "%";
        textMeshProUGUI.color = Color.red;
    }

    void Pump() {
        if(curr_fuel < 70) {
            curr_fuel += 3;
            textMeshProUGUI.text = curr_fuel.ToString() + "%";
            if (curr_fuel < 10) {
                textMeshProUGUI.color = Color.red;
            }
            else if (curr_fuel < 70) {
                textMeshProUGUI.color = Color.yellow;
            }
            else {
                textMeshProUGUI.color = Color.green;
                is_ok = true;
            }
            timerReached = false;
        }
        else if(curr_fuel < 100) {
            curr_fuel += 1;
            textMeshProUGUI.text = curr_fuel.ToString() + "%";
            timerReached = false;
        }
    }

    float timer = 0f;
    bool timerReached = false;
    // Update is called once per frame
    void Update()
    {
        is_on = gameObject.GetComponent<Glowing>().is_on;
        isHolding = tank.GetComponent<HoldCharger>().isHolding;
        if(is_on){
            panel.SetActive(true);
            textMeshProUGUI.text = curr_fuel.ToString() + "%";
            if (curr_fuel < 10) {
                textMeshProUGUI.color = Color.red;
            }
            else if (curr_fuel < 70) {
                textMeshProUGUI.color = Color.yellow;
            }
            else {
                textMeshProUGUI.color = Color.green;
                is_ok = true;
            }
        }
        else if(!is_connected){
            panel.SetActive(false);
        }
        if(tank.GetComponent<HoldCharger>().charging){
            if(is_connected){
                panel.SetActive(true);       
                /*if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.45f)
                    {
                        animator.speed = 0f;   
                    }*/
                if (!timerReached) 
                    timer += Time.deltaTime;
                    
                if (!timerReached && timer > .25f){
                    timerReached = true;
                    timer = 0;
                    Pump();  
                }   
            }
        }
        if(is_ok && is_connected){
            animator.speed = 1;
        }
    }

    void OnTriggerEnter(Collider c) {
        if (c.gameObject == tank && !tank.GetComponent<HoldCharger>().charging && !is_ok){
            is_connected = true;
            tank.GetComponent<HoldCharger>().charging = true;
            tank.GetComponent<HoldCharger>().isHolding = false;
        }
    }
}
