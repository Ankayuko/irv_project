using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FruitInfo : MonoBehaviour {

    public Text red_text;
    public Text blue_text;
    public Text purple_text;
    public Text yellow_text;
    public Text green_text;
    public Text pick_fruit;
    public static FruitInfo instance;

    void Start()
    {
        UpdateInfo();
        UserResources.OnChange += UpdateInfo;
        pick_fruit.gameObject.SetActive(false);
    }

    public void UpdateInfo()
    {
      
        red_text.text = UserResources.red_fruit.ToString();
        blue_text.text = UserResources.blue_fruit.ToString();
        purple_text.text = UserResources.purple_fruit.ToString();
        yellow_text.text = UserResources.yellow_fruit.ToString();
        green_text.text = UserResources.green_fruit.ToString();

        pick_fruit.gameObject.SetActive(true);
        Coroutine coroutine = GameManager.Get().StartCoroutine(DestroyText(0.3f));
    }

    private IEnumerator DestroyText(float delay)
    {
        yield return new WaitForSeconds(delay);
        Debug.Log("Destroy particle");
        pick_fruit.gameObject.SetActive(false);
    }

}
