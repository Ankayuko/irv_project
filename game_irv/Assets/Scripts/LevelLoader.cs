using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour {

    private static AsyncOperation operation;

    public delegate void LoadChange(float value);
    public static event LoadChange OnLoadChange;

    public delegate void LoadStart();
    public static event LoadStart OnLoadStart;

    public static IEnumerator LoadAsyncUpdate()
    {
        
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            Debug.Log(progress);
            OnLoadChange(operation.progress);
            yield return new WaitForEndOfFrame();
        }

        OnLoadChange(operation.progress);
    }


    public static void LoadAsync(int sceneIndex)
    {
        OnLoadStart();
        operation = SceneManager.LoadSceneAsync(sceneIndex, LoadSceneMode.Single);
        GameManager.Get().StartCoroutine(LoadAsyncUpdate());
       
    }

}
