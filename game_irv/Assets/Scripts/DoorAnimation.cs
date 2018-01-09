using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnimation : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
   
    }

    private void OnTriggerEnter(Collider col)
    {
        Debug.Log(col.tag);
        if (col.tag == "Player")
        {
            animator.SetBool("open", true);
        }
    }

   
}
