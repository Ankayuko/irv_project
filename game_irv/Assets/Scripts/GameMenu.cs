using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameMenu : MonoBehaviour {

    public static bool GameIsPaused = false;
    public bool gameIsOver = false;
    public GameObject GameMenuUI;
    public GameObject AudioMenuUI;
    public GameObject GameOverUI;
    public Slider[] volumeSliders;
    public Text ambientText;
    public Text backgroundText;
    public Text sfxText;
	

    void Start()
    { 
        volumeSliders[0].value = AudioManager.instance.volBackground;
        volumeSliders[1].value = AudioManager.instance.volAmbient;
        volumeSliders[2].value = AudioManager.instance.volSfx;
    }

	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape) && AudioMenuUI.activeSelf==false && GameOverUI.activeSelf==false)
        {
            if (GameIsPaused)
            {
                Resume();
            } else

            {
                Pause();
                
            }
        }

        if (SceneManager.GetActiveScene().buildIndex == 2 && UserResources.red_fruit >= 50 &&
         UserResources.blue_fruit >= 50 && UserResources.yellow_fruit >= 50 && UserResources.purple_fruit >= 50
         && UserResources.green_fruit >= 50)
        {
            Game_over();
        }
        

    }


    public void Game_over()
    {
        GameOverUI.SetActive(true);
        Time.timeScale = 0f;
       
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
        
        SceneManager.LoadSceneAsync(0);
        
    }

    public void Audio()
    {
        Pause();
        GameMenuUI.SetActive(false);
        AudioMenuUI.SetActive(true);
      
    }


    public void QuitGame()
    {
        Debug.Log("quitting game...");
        Application.Quit();
    }


    public void SetVolumeMusic(float value)
    {
        AudioManager.instance.SetVolume(AudioManager.AudioChannel.background, value);
        backgroundText.text = (value * 100).ToString("0");
    }

    public void SetVolumeSFX(float value)
    {
        AudioManager.instance.SetVolume(AudioManager.AudioChannel.sfx, value);
        sfxText.text = (value * 100).ToString("0");
    }

    public void SetVolumeAmbient(float value)
    {
        AudioManager.instance.SetVolume(AudioManager.AudioChannel.ambient, value);
        ambientText.text = (value * 100).ToString("0");
    }
}
