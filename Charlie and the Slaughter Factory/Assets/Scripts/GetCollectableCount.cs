using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GetCollectableCount : MonoBehaviour
{

    public Text chickenText;
    private int chickens = 0;

    //Set the chickens saved text as the number of chickens collected in the level just completed
    void Start()
    {
        chickens = PlayerPrefs.GetInt("LevelCollectables");
        chickenText.text = chickens.ToString();
    }

}
