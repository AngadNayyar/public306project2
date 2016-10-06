using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CoinCalculate : MonoBehaviour {

    public Text coinsText;

    private float time;
    public int coins;

    // Use this for initialization
    void Start () {
        time = PlayerPrefs.GetFloat("endTime");

        if (time < 4) {
            coins = 3;
        } else if (time < 6) {
            coins = 2;
        } else {
            coins = 1;
        }

        coinsText.text = coins.ToString();

    }
}
