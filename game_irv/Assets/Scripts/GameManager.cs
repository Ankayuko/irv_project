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
            Init();
        }
        else
        {
            Destroy(gameObject);
           
        }
    }

    private void Init()
    {
     
        GameData.NewGame();
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

   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L) && SceneManager.GetActiveScene().buildIndex !=0 && SceneManager.GetActiveScene().buildIndex!=2
            &&UserResources.red_fruit>= 20 && UserResources.blue_fruit >= 20 && UserResources.yellow_fruit >= 20 && UserResources.purple_fruit >= 20
            && UserResources.green_fruit >= 20)

        {
            Debug.Log("Async loading");
            LevelLoader.LoadAsync(2);
        }


        if (Input.GetKeyDown(KeyCode.J))
        {
          
           GameData.Save();
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
          
            GameData.Load();
        }

    }
 

}
