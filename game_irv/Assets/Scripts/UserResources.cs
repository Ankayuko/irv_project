﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserResources : MonoBehaviour
{

    public static int red_fruit { get; private set; }
    public static int blue_fruit { get; private set; }
    public static int purple_fruit { get; private set; }
    public static int yellow_fruit { get; private set; }
    public static int green_fruit { get; private set; }

    public delegate void FruitCollected();
    public static event FruitCollected OnChange;

    public UserResources()
    { }

    public static void CollectFruit(string tag)
    { if (tag == "red_fruit_tag")
            red_fruit++;
        else if (tag == "blue_fruit_tag")
            blue_fruit++;
        else if (tag == "purple_fruit_tag")
            purple_fruit++;
        else if (tag == "yellow_fruit_tag")
            yellow_fruit++;
        else if (tag == "green_fruit_tag")
            green_fruit++;
        

        if (OnChange != null)
        {
            OnChange();
        }
    }

    public static void UpdateFruit(int red, int blue, int green, int yellow, int purple)
    {
        red_fruit = red;
        blue_fruit = blue;
        purple_fruit = purple;
        yellow_fruit = yellow;
        green_fruit = green;
        if (OnChange != null)
        {
            OnChange();
        }       
    }

 
}

