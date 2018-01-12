using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PickUpFruit : MonoBehaviour {


  

    void OnTriggerEnter()
    {

       // Debug.Log(gameObject.tag);
        UserResources.CollectFruit(gameObject.tag);
        AudioManager.instance.PlaySfx(AudioResources.instance.sfxMusic);
        this.GetComponent<SphereCollider>().enabled = false;
        this.GetComponent<MeshRenderer>().enabled = false;

        // Destroy the pickup object
        Destroy(gameObject);

    }

}
