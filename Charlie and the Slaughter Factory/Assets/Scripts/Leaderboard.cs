using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

/*
 * This class displays player usernames and their corresponding
 * score for the leaderboard in order from highest score to lowest
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
    private string username;

    void Start () {
        GameObject gameO = GameObject.Find("GameController");
        GameController gameC = (GameController)gameO.GetComponent(typeof(GameController));
        
        //get the sorted list of users
        List<User> players = gameC.SetUpLeaderboard();

        //check username is not empty (empty player slot) and if not
        //set the texts to the username and corresponding score
        username = players[0].GetUsername();
        if (username != "")
        {
            firstPlaceUsername.text = players[0].GetUsername();
            firstPlaceScore.text = players[0].GetScore().ToString();
        }

        username = players[1].GetUsername();
        if (username != "")
        {
            secondPlaceUsername.text = players[1].GetUsername();
            secondPlaceScore.text = players[1].GetScore().ToString();
        }

        username = players[2].GetUsername();
        if (username != "")
        {
            thirdPlaceUsername.text = players[2].GetUsername();
            thirdPlaceScore.text = players[2].GetScore().ToString();
        }

        username = players[3].GetUsername();
        if (username != "")
        {
            fourthPlaceUsername.text = players[3].GetUsername();
            fourthPlaceScore.text = players[3].GetScore().ToString();
        }
    }

}
