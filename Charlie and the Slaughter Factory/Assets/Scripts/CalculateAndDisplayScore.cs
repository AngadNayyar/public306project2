﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class CalculateAndDisplayScore : MonoBehaviour
{
    public Text scoreText;
    private float oldTotalScore;
    private float displayedScore;
    private float newTotalScore;
    
    void Start()
    {
        /*
         * Get the current player
         */
        GameObject gameO = GameObject.Find("GameController");
        GameController gameC = (GameController)gameO.GetComponent(typeof(GameController));
        User currentPlayer = gameC.getCurrentPlayer();
        Debug.Log(currentPlayer);
        Debug.Log(currentPlayer.GetPlayerSlot());
        string playerSlot = currentPlayer.GetPlayerSlot();

        /* 
         * Calculate new score
         */
        //get the time it took the player to finish the level and the level 
        //that the player is on (higher levels give more points for completion)
        int time = (int)PlayerPrefs.GetFloat("endTime");
        int health = PlayerPrefs.GetInt("health");

        //reset health player pref
        PlayerPrefs.SetInt("health", 100);

        //calculate the score for the level just finished based on the level number,
        //the time taken to complete the level and the players remaining health
        int thisLevelScore = health - time;

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
        StartCoroutine(IncrementScoreDisplay());
    }

    //every 0.05 seconds increase the score
    IEnumerator IncrementScoreDisplay()
    {
        if (displayedScore < newTotalScore)
        {
            displayedScore += 1;
            scoreText.text = displayedScore.ToString();
        }
        yield return new WaitForSecondsRealtime(0.009f);
    }

}
