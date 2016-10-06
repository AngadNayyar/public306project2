using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DisplayScore : MonoBehaviour {

    public Text scoreText;

    // Use this for initialization
    void Start () {
        int oldScore = PlayerPrefs.GetInt("CurrentScore");

        int thisLevelScore = 0; //calculate score

        if (thisLevelScore < 0) {
            thisLevelScore = 0;
        }

        int newScore = 10;

        //int newScore = DisplayUserData.UpdateCurrentScore(thisLevelScore);
        scoreText.text = newScore.ToString();
    }
}
