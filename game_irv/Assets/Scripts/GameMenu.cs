using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour {

    public static bool GameIsPaused = false;
    public GameObject GameMenuUI;
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            } else

            {
                Pause();

            }
        }
	}

    public void Resume()
    {
        GameMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        GameMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Debug.Log("quitting game...");
        Application.Quit();
    }

}
