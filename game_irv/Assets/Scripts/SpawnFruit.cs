using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFruit : MonoBehaviour {

    public GameObject fruit;
    int nr_instante = 20;

    void spawn()
    {
        for(int i=0; i< nr_instante; i++)
        {
            Vector3 poz_fruit = new Vector3(this.transform.position.x + Random.Range(-1.0f, 1.0f),
                                          this.transform.position.y + Random.Range(0.0f, 3.0f),
                                          this.transform.position.z + Random.Range(-1.0f, 1.0f));
            Instantiate(fruit, poz_fruit, Quaternion.identity);
        }
    }
	// Use this for initialization
	void Start () {

        spawn();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
