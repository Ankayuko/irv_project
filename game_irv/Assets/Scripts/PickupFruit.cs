using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PickUpFruit : MonoBehaviour {

    public  ParticleSystem particles;
    

    void OnTriggerEnter()
    {

       // Debug.Log(gameObject.tag);
        UserResources.CollectFruit(gameObject.tag);
        AudioManager.instance.PlaySfx(AudioResources.instance.sfxMusic);
        this.GetComponent<SphereCollider>().enabled = false;
        this.GetComponent<MeshRenderer>().enabled = false;
        

        particles.Play();
        particles.transform.SetParent(transform.parent);

        // Starts a couroutine using the GameManager MonoBehaviour
        Coroutine coroutine = GameManager.Get().StartCoroutine(DestroyParticle(5));

        // Destroy the pickup object
         Destroy(gameObject);

    }


    private IEnumerator DestroyParticle(float delay)
    {
        yield return new WaitForSeconds(delay);
        Debug.Log("Destroy particle");
        Destroy(particles.gameObject);
    }


}
