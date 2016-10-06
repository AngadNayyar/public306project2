using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GetCoinCount : MonoBehaviour
{

    public Text coinText;
    private int coins;

    //Set the coin text as the number of coins collected in the level just completed
    void Start()
    {
        coins = PlayerPrefs.GetInt("LevelCoins");
        coinText.text = coins.ToString();
    }

}
