using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingBar : MonoBehaviour
{

    public Slider loadingBar;
    


    void Start()
    {
        gameObject.SetActive(false);
       


        LevelLoader.OnLoadStart += () =>
        {  
            gameObject.SetActive(true);
         
        };

        LevelLoader.OnLoadChange += ((float value) =>
        {
            loadingBar.value = value;
            if (value == 1)
            {
                gameObject.SetActive(false);
               
            }
         
        });
    }
}