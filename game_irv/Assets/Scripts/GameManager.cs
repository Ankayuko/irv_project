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
    public static GamePlayState gameState;


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

    private void Init()
    {
       // AudioManager.Init();
       // GameData.Load();
        SetGameState(GamePlayState.Gameplay);
    }

    public static void SetGameState(GamePlayState state)
    {
        gameState = state;
        if (gameState == GamePlayState.GameMenu)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Confined;
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
            LevelLoader.LoadAsync(2);
        }

    }
  

}
