using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GamePlayState
{
    Gameplay,
    GameMenu
}

public class GameManager : MonoBehaviour
{
    private static GameManager Instance;


    public static GameManager Get()
    {
        return Instance;
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
     
        }
        else
        {
            Destroy(gameObject);
           
        }
    }

    // Use this for initialization
    void Start()
    {

    }



    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))

        {
            Debug.Log("Async loading");
            LevelLoader.LoadAsync(1);
        }

    }
  

}
