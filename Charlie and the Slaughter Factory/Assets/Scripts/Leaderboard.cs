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
        firstPlaceScore.text = players[0].GetScore().ToString();

        secondPlaceUsername.text = players[1].GetUsername();
        secondPlaceScore.text = players[1].GetScore().ToString();

        thirdPlaceUsername.text = players[2].GetUsername();
        thirdPlaceScore.text = players[2].GetScore().ToString();

        fourthPlaceUsername.text = players[3].GetUsername();
        fourthPlaceScore.text = players[3].GetScore().ToString();

        //implement check to see if empty username - don't display anything

    }

}
