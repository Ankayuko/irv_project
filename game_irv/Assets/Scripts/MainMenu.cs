using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

public void PlayGame()
    {
        GameData.NewGame();
        SceneManager.LoadSceneAsync(1);
    }

 public void LoadFromSaved()
    {
        GameData.Load();
        SceneManager.LoadSceneAsync(GameData.Instance.sceneIndex);
    }

public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quiting game..");
    }
}
