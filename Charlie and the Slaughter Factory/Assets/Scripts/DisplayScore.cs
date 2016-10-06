using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class DisplayScore : MonoBehaviour {

    public Text scoreText;
    //public DisplayUserData dUD;

    // calculate the score for the level and add it to the player's current score
    // then set the new current score to the text label
    void Start () {
        //get the time it took the player to finish the level and the level 
        //that the player is on (higher levels give more points for completion)
        int levelNumber = Int32.Parse(PlayerPrefs.GetString("CurrentScene")) - 1;
        int time = (int)PlayerPrefs.GetFloat("endTime");
        int health = PlayerPrefs.GetInt("endHealth");

        //calculate the score for the level just finished based on the level number,
        //the time taken to complete the level and the players remaining health
        int thisLevelScore = (levelNumber * 100) - time + health;

        //if the player scored lower than 0, set the score to 0 so as not to
        //lower the score
        if (thisLevelScore < 0) {
            thisLevelScore = 0;
        }

        //get the new score back (old score + just calculated score)
        //int newScore = dUD.UpdateCurrentScore(thisLevelScore);
        int currentScore = PlayerPrefs.GetInt("CurrentScore");
        int updatedScore = currentScore + thisLevelScore;
        PlayerPrefs.SetInt("CurrentScore", updatedScore);

        //update the score text
        scoreText.text = updatedScore.ToString();
    }
}
