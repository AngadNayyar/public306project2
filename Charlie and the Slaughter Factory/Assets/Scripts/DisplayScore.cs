using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DisplayScore : MonoBehaviour
{

    public Text scoreText;

    // display the players total score for the game
    public void Start()
    {
        /*
         * Get the current player
         */
        GameObject gameO = GameObject.Find("GameController");
        GameController gameC = (GameController)gameO.GetComponent(typeof(GameController));
        User currentPlayer = gameC.getCurrentPlayer();
        string playerNumber = currentPlayer.GetPlayerSlot();

        int score = PlayerPrefs.GetInt("CurrentScore" + playerNumber);
        scoreText.text = "Score: " + score;
    }
}
