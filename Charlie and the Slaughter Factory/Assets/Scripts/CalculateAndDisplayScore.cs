using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class CalculateAndDisplayScore : MonoBehaviour
{

    public Text scoreText;
    private float oldTotalScore;
    private float displayedScore;
    private float newTotalScore;
    //time taken to increment to new current score
    private float pointAnimDurationSec = 1f;
    private float pointAnimTimer = 0f;
    
    void Start()
    {
        /*
         * Get the current player
         */
        GameObject gameO = GameObject.Find("GameController");
        GameController gameC = (GameController)gameO.GetComponent(typeof(GameController));
        User currentPlayer = gameC.getCurrentPlayer();
        string playerSlot = currentPlayer.GetPlayerSlot();

        /* 
         * Calculate new score
         */
        //get the time it took the player to finish the level and the level 
        //that the player is on (higher levels give more points for completion)
        int levelNumber = Int32.Parse(PlayerPrefs.GetString("CurrentScene")) - 1;
        int time = (int)PlayerPrefs.GetFloat("endTime");
        int health = PlayerPrefs.GetInt("endHealth");

        //calculate the score for the level just finished based on the level number,
        //the time taken to complete the level and the players remaining health
        int thisLevelScore = (levelNumber * 10) - time + health;

        //if the player scored lower than 0, set the score to 0 so as not to
        //lower the score
        if (thisLevelScore < 0)
        {
            thisLevelScore = 0;
        }


        /* 
         * Set up variables for Lerp and set new current score
         */
        // get the old total score for the start point of the Lerp and 
        // the calculation of the new score
        oldTotalScore = currentPlayer.GetScore();

        // the score to be updated and displayed (start at old total score)
        displayedScore = oldTotalScore;

        // get the new total score for the end point of the Lerp and to save it to the user
        newTotalScore = oldTotalScore + thisLevelScore;
        currentPlayer.SetScore((int)newTotalScore);
        PlayerPrefs.SetInt(playerSlot + "Score", (int)newTotalScore);
    }

    void Update()
    {
        // change the total score text to the latest increment until the new total score is displayed
        pointAnimTimer += Time.deltaTime;
        float prcComplete = pointAnimTimer / pointAnimDurationSec;
        displayedScore = Mathf.Lerp(oldTotalScore, newTotalScore, prcComplete);
        scoreText.text = displayedScore.ToString("0");
    }

}
