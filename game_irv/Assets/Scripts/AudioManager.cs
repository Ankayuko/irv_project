using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
 public enum AudioChannel { background, ambient, sfx};

    public float volBackground { get; private set; }
    public float volAmbient { get; private set; }
    public float volSfx { get; private set; }

      AudioSource backgroundMusic;
      AudioSource ambientMusic;
    AudioSource sfxMusic;
    

    public static AudioManager instance;


    


     void Awake()
    {

        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            backgroundMusic = new AudioSource();
            ambientMusic = new AudioSource();
            sfxMusic = new AudioSource();

            GameObject newBackgroundMusic = new GameObject("Background Music");
            GameObject newAmbientMusic = new GameObject("Ambient Music");
            GameObject newSfxMusic = new GameObject("Sfx Music");

            backgroundMusic = newBackgroundMusic.AddComponent<AudioSource>();
            ambientMusic = newAmbientMusic.AddComponent<AudioSource>();
            sfxMusic= newSfxMusic.AddComponent<AudioSource>();

            newBackgroundMusic.transform.parent = transform;
            newAmbientMusic.transform.parent = transform;
            newSfxMusic.transform.parent = transform;
            

            volBackground = PlayerPrefs.GetFloat("volBackground", 1);
            volAmbient = PlayerPrefs.GetFloat("volAmbient", 1);
            volSfx = PlayerPrefs.GetFloat("volSFX", 1);
        }
    }


    public  void SetVolume(AudioChannel channel, float volume)
    {
        switch (channel)
        {
            case AudioChannel.ambient:
                volAmbient = volume;
                break;

            case AudioChannel.background:
                volBackground = volume;
                break;

            case AudioChannel.sfx:
                volSfx = volume;
                break;

            default:
                break;
        }
        backgroundMusic.volume = volBackground;
        ambientMusic.volume = volAmbient;
        sfxMusic.volume = volSfx;
        
        
        

        PlayerPrefs.SetFloat("volBackground", volBackground);
        PlayerPrefs.SetFloat("volAmbient", volAmbient);
        PlayerPrefs.SetFloat("volSFX", volSfx);
        PlayerPrefs.Save();
    }



    public void PlayBackgroundMusic(AudioClip clip)
    {   
        backgroundMusic.clip = clip;
        backgroundMusic.Play();
        
    }



    public void PlaySfx(AudioClip clip)
    {
        sfxMusic.clip = clip;
        sfxMusic.Play();
    }
    



    public  void PlayAmbient(AudioClip clip)
    {
        ambientMusic.clip = clip;
        ambientMusic.Play();

        // If source was not added, add it

    }



    //public static void Init()
    //{
    //    init = true;
    //    volBackground = PlayerPrefs.GetFloat("volBackground", 1);
    //    volVoice = PlayerPrefs.GetFloat("volVoice", 1);
    //    volSfx = PlayerPrefs.GetFloat("volSfx", 1);

    //}

    //public static float GetVolume(AudioChannel channel)
    //{
    //    if (!init)
    //        Init();

    //    switch (channel)
    //    {
    //        case AudioChannel.voice:
    //            return volVoice;

    //        case AudioChannel.background:
    //            return volBackground;

    //        case AudioChannel.sfx:
    //            return volSfx;
    //    }

    //    return 0;
    //}




    //public static void SaveSettings()
    //{
    //    PlayerPrefs.SetFloat("volBackground", volBackground);
    //    PlayerPrefs.SetFloat("volSfx", volSfx);
    //    PlayerPrefs.SetFloat("volVoice", volVoice);
    //}


   

   
}


