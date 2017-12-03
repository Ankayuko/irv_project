using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnFruit : MonoBehaviour {


    void OnTriggerEnter()
    {
        this.GetComponent<SphereCollider>().enabled = false;
        this.GetComponent<MeshRenderer>().enabled = false;
        Invoke("respawn", 10);
    }

    void respawn()
    {
        this.GetComponent<SphereCollider>().enabled = true;
        this.GetComponent<MeshRenderer>().enabled = true;
    }
	// Use this for initialization
	void Start () {

      
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
