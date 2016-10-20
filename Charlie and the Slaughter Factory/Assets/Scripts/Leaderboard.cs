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
        int numPlayers = players.Count;

        if (numPlayers > 0)
        {
            firstPlaceUsername.text = players[0].GetUsername();
            firstPlaceScore.text = players[0].GetScore().ToString();

            if (numPlayers > 1)
            {
                secondPlaceUsername.text = players[1].GetUsername();
                secondPlaceScore.text = players[1].GetScore().ToString();

                if (numPlayers > 2)
                {
                    thirdPlaceUsername.text = players[2].GetUsername();
                    thirdPlaceScore.text = players[2].GetScore().ToString();

                    if (numPlayers > 3)
                    {
                        fourthPlaceUsername.text = players[3].GetUsername();
                        fourthPlaceScore.text = players[3].GetScore().ToString();
                    }
                }
            }

        }
    }

}
