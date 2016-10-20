using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class CalculateAndDisplayScore : MonoBehaviour
{
    public Text scoreText;
    private int displayedScore;
    private int newTotalScore;
    private int oldTotalScore;


    void Update()
    {
        /*
	
        GameObject gameO = GameObject.Find("GameController");
        GameController gameC = (GameController)gameO.GetComponent(typeof(GameController));
        User currentPlayer = gameC.getCurrentPlayer();
        string playerSlot = currentPlayer.GetPlayerSlot();	
	
		newTotalScore = currentPlayer.GetScore();
		displayedScore = currentPlayer.GetOldScore();

       
        //get the time it took the player to finish the level and the level 
        //that the player is on (higher levels give more points for completion)
        int time = (int)PlayerPrefs.GetFloat("endTime");
        int health = PlayerPrefs.GetInt("health");

        //reset health player pref
        PlayerPrefs.SetInt("health", 100);

        //calculate the score for the level just finished based on the level number,
        //the time taken to complete the level and the players remaining health
        int thisLevelScore = 500 - (100 - health) - time;

        //if the player scored lower than 0, set the score to 0 so as not to
        //lower the score
        if (thisLevelScore < 0)
        {
            thisLevelScore = 0;
        }


        // get the old total score for the start point of the Lerp and 
        // the calculation of the new score
        oldTotalScore = currentPlayer.GetScore();
        currentPlayer.SetOldScore(oldTotalScore);

        // the score to be updated and displayed (start at old total score)
        displayedScore = oldTotalScore;

        // get the new total score for the end point of the Lerp and to save it to the user
        newTotalScore = oldTotalScore + thisLevelScore;
        currentPlayer.SetScore((int)newTotalScore);
        PlayerPrefs.SetInt(playerSlot + "Score", (int)newTotalScore);
        */

        int display = PlayerPrefs.GetInt("display");

        scoreText.text = display.ToString();

    }

}
