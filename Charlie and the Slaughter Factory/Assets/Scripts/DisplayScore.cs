using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DisplayScore : MonoBehaviour
{

    public Text scoreText;

    // display the players total score for the game
    public void Start()
    {
        int score = PlayerPrefs.GetInt("CurrentScore");
        scoreText.text = "Score: " + score;
    }
}
