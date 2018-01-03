using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroyThis : MonoBehaviour {

    public static DontDestroyThis instance;

    void Awake() {

        if (instance == null)
            instance = this;
        else
            Destroy(transform.gameObject);

        DontDestroyOnLoad(transform.gameObject);
    }

}
