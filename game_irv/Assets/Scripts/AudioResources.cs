using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class AudioResources : MonoBehaviour
{

    public AudioClip BackgroundMusic;
    public AudioClip AmbientMusic;
    

    void Start()
    {   
        AudioManager.instance.PlayBackgroundMusic(BackgroundMusic);
        AudioManager.instance.PlayAmbient(AmbientMusic);
    }
}