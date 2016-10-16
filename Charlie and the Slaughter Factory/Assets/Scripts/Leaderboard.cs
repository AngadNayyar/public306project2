using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

/*
 * This class displays the correct players in the correct order
 * for the leaderboard
 */
public class Leaderboard : MonoBehaviour {

    public Text firstPlaceUsername;
    public Text firstPlaceScore;
    public Text secondPlaceUsername;
    public Text secondPlaceScore;
    public Text thirdPlaceUsername;
    public Text thirdPlaceScore;
    public Text fourthPlaceUsername;
    public Text fourthPlaceScore;

    void Start () {
        GameObject gameO = GameObject.Find("GameController");
        GameController gameC = (GameController)gameO.GetComponent(typeof(GameController));
        
        List<User> players = gameC.SetUpLeaderboard();

        firstPlaceUsername.text = players[0].GetUsername();
        firstPlaceScore.text = PlayerPrefs.GetInt("CurrentScorePlayer1").ToString();

        secondPlaceUsername.text = players[1].GetUsername();
        secondPlaceScore.text = PlayerPrefs.GetInt("CurrentScorePlayer2").ToString();

        thirdPlaceUsername.text = players[2].GetUsername();
        thirdPlaceScore.text = PlayerPrefs.GetInt("CurrentScorePlayer3").ToString();

        fourthPlaceUsername.text = players[3].GetUsername();
        fourthPlaceScore.text = PlayerPrefs.GetInt("CurrentScorePlayer4").ToString();

        //implement check to see if empty username - don't display anything

    }

}
