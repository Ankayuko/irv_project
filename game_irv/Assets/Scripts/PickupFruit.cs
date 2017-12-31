using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpFruit : MonoBehaviour {

    public AudioClip collect_fruit;

    void OnTriggerEnter()
    {

        AudioManager.instance.PlaySfx(collect_fruit, transform.position);
        this.GetComponent<SphereCollider>().enabled = false;
        this.GetComponent<MeshRenderer>().enabled = false;
        //AudioManager.PlaySfx(AudioResources.Instance.collect_fruit);
        Debug.Log("here");
        //Invoke("respawn", 10);
    }
    //void respawn()
    //{
    //    this.GetComponent<SphereCollider>().enabled = true;
    //    this.GetComponent<MeshRenderer>().enabled = true;
    //}
	// Use this for initialization
	void Start () {

      
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
