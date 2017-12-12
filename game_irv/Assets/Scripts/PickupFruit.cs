using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickupFruit : MonoBehaviour {

    public GameObject inventoryPanel;



    void OnTriggerEnter(Collider collision)
    {
        foreach (Transform child in inventoryPanel.transform)
        {
            if (child.gameObject.tag == collision.gameObject.tag)
            {
                string c = child.Find("Text").GetComponent<Text>().text;
                int count = System.Int32.Parse(c) + 1;
                child.Find("Text").GetComponent<Text>().text = "" + count;
                
            }
                
        }
    }
	
}
