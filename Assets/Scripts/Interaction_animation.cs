using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction_animation : MonoBehaviour
{
    public GameObject hand;
    Animator anim;
    Interaction sc;
    BoxCollider boxCollider;

    void Start()
    {
        anim = GetComponent<Animator>();
        boxCollider = hand.GetComponent<BoxCollider>();
    }
    void Update()
    {
        // Checks if animation is playing. If so, enables the box collider on the hand after a delay to prevent unwanted physical interaction.
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Pressing"))
        {
            if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.3f)
            {
                boxCollider.enabled = true;
            }            
        }
        else if (anim.GetCurrentAnimatorStateInfo(0).IsName("Plug"))
        {
            if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.3f)
            {
                boxCollider.enabled = true;
            }            
        }
        else if (anim.GetCurrentAnimatorStateInfo(0).IsName("Standing"))
        {
            if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.3f)
            {
                boxCollider.enabled = true;
            }            
        }
        // If animation is not playing at the moment, plays it when "e" key pressed.
        else
        {
            if (Input.GetKeyDown("e"))
            {
                anim.Play("Crouch");
            }
            if (Input.GetKeyDown("r"))
            {
                anim.Play("Plug");
            }
            if (Input.GetKeyDown("t"))
            {
                anim.Play("Pressing");
            }
        // Disables the box collider on the hand to prevent unwanted physical interaction.
            boxCollider.enabled = false;
        }
    }
}
