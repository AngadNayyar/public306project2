using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class CalculateAndDisplayScore : MonoBehaviour
{
    public Text scoreText;
    private int displayedScore;
    private int newTotalScore;


    void Update()
    {		
		/*
         * Get the current player
         */
        GameObject gameO = GameObject.Find("GameController");
        GameController gameC = (GameController)gameO.GetComponent(typeof(GameController));
        User currentPlayer = gameC.getCurrentPlayer();
        Debug.Log(currentPlayer);
        Debug.Log(currentPlayer.GetPlayerSlot());		
	
		newTotalScore = currentPlayer.GetScore();
		displayedScore = currentPlayer.GetOldScore();
		
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
