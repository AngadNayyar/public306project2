using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GetCollectableCount : MonoBehaviour
{

    public Text chickenText;
    private int chickens = 0;

    void Start()
    {
        //Set the chickens saved text as the number of chickens collected so far in the game
        chickens = PlayerPrefs.GetInt("Collectables");
        chickenText.text = chickens.ToString();
    }

}
