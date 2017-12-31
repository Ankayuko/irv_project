using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMenu : MonoBehaviour {

    public static bool GameIsPaused = false;
    public GameObject GameMenuUI;
    public GameObject AudioMenuUI;
    public Slider[] volumeSliders;
	

    void Start()
    {
        volumeSliders[0].value = AudioManager.instance.volBackground;
        volumeSliders[1].value = AudioManager.instance.volAmbient;
        volumeSliders[2].value = AudioManager.instance.volSfx;
    }



	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape) && AudioMenuUI.active==false)
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
        Cursor.visible = true;
        
    }

    public void Audio()
    {
        Pause();
        GameMenuUI.SetActive(false);
        AudioMenuUI.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.lockState = CursorLockMode.None;
    }


    public void QuitGame()
    {
        Debug.Log("quitting game...");
        Application.Quit();
    }


    public void SetVolumeMusic(float value)
    {
        AudioManager.instance.SetVolume(AudioManager.AudioChannel.background, value);
    }

    public void SetVolumeSFX(float value)
    {
        AudioManager.instance.SetVolume(AudioManager.AudioChannel.sfx, value);
    }

    public void SetVolumeAmbient(float value)
    {
        AudioManager.instance.SetVolume(AudioManager.AudioChannel.ambient, value);
    }
}
