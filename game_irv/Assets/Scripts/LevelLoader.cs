using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour {

    private static AsyncOperation operation;

    public static IEnumerator LoadAsyncUpdate(int sceneIndex)
    {
        
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            Debug.Log(progress);
            yield return null;
        }
    }


    public static void LoadAsync(int sceneIndex)
    {
        operation = SceneManager.LoadSceneAsync(sceneIndex);
        GameManager.Get().StartCoroutine(LoadAsyncUpdate(sceneIndex));
       
    }

}
