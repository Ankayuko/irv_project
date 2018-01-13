using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

using UnityEngine;
using UnityEngine.SceneManagement;

// For XML serialization
using System.Xml.Serialization;

[XmlRoot("GameData")]
public class GameData
{
    public static GameData Instance = new GameData();
    private static string XMLFileName = "/GameData.xml";
    private static string gameDataFile = Application.persistentDataPath + XMLFileName;


    private static bool isLoaded;
    public delegate void LoadEvent();
    public static event LoadEvent OnLoad;


    [XmlElement("Scene_index")]
    public int sceneIndex;

    [XmlElement("Red_fruit")]
    public int red_fruit;

    [XmlElement("Blue_fruit")]
    public int blue_fruit;

    [XmlElement("Yellow_fruit")]
    public int yellow_fruit;

    [XmlElement("Purple_fruit")]
    public int purple_fruit;

    [XmlElement("Green_fruit")]
    public int green_fruit;




    public static void Save()
    {
        Instance.sceneIndex = SceneManager.GetActiveScene().buildIndex;
        Instance.red_fruit = UserResources.red_fruit;
        Instance.blue_fruit = UserResources.blue_fruit;
        Instance.yellow_fruit = UserResources.yellow_fruit;
        Instance.purple_fruit = UserResources.purple_fruit;
        Instance.green_fruit = UserResources.green_fruit;
        

        // Save game state into XML
        Debug.Log(gameDataFile);
        var serializer = new XmlSerializer(typeof(GameData));
        var stream = new FileStream(gameDataFile, FileMode.Create);
        serializer.Serialize(stream, Instance);
        stream.Close();
        
    }

    public static void Load()
    {
        Debug.Log(gameDataFile);

        if (File.Exists(gameDataFile))
        {
            // Load info from XML
            var serializer = new XmlSerializer(typeof(GameData));
            var stream = new FileStream(gameDataFile, FileMode.Open);
            try
            {
                Instance = serializer.Deserialize(stream) as GameData;
                stream.Close();

                Debug.Log("Gameplay loaded: " + gameDataFile);
            
                UserResources.UpdateFruit(Instance.red_fruit, Instance.blue_fruit, Instance.green_fruit, Instance.yellow_fruit, Instance.purple_fruit);

           
                isLoaded = true;
                if (OnLoad != null)
                    OnLoad();
            }
            catch (SystemException e)
            {
                stream.Close();
                NewGame();
                Save();
            }
        }
        else
        {
            NewGame();
            Save();
        }

    }

    public static void NewGame()
    {
        Instance.sceneIndex = 1;
        Instance.red_fruit = 0;
        Instance.blue_fruit = 0;
        Instance.green_fruit = 0;
        Instance.purple_fruit = 0;
        Instance.yellow_fruit = 0;
        UserResources.UpdateFruit(Instance.red_fruit, Instance.blue_fruit, Instance.green_fruit, Instance.yellow_fruit, Instance.purple_fruit);

    }


    public static void OnDataInit(LoadEvent callback)
    {
        OnLoad += callback;

        if (isLoaded == true)
        {
            callback();
        }
        else
        {
            Debug.Log("Game Data Not loaded!");
        }
    }

    public static void RemoveCallback(LoadEvent callback)
    {
        OnLoad -= callback;
    }
}
