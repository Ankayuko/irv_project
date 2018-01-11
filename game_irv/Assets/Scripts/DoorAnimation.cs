using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnimation : MonoBehaviour
{
    private Animator animator;
    public ParticleSystem particles;
    

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
            particles.Play();
            Coroutine coroutine = GameManager.Get().StartCoroutine(DestroyParticle(5));
        }

        
        
    }

    private IEnumerator DestroyParticle(float delay)
    {
        yield return new WaitForSeconds(delay);
        Debug.Log("Destroy particle");
        particles.Stop();
    }

}
