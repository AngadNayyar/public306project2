using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/*
 * This class displays the correct players in the correct order
 * for the leaderboard
 */
public class Leaderboard : MonoBehaviour {

    public GameController gc;

	void Start () {

        //List<User> players = gc.SetUpLeaderboard();

	    
	}

    /*
    // Update the strings contained in the leaderboard.
    public void UpdateLeaderboardView(GameObject panel)
    {
        Text[] textViews = panel.GetComponentsInChildren<Text>();
        panel.SetActive(true);
        string usernames = "";
        string scores = "";
        for (int i = 0; i < leaderboard.Count; i++)
        {
            usernames = usernames + (i + 1) + ". " + leaderboard[i].GetUsername() + "\n";
            scores = scores + leaderboard[i].GetHighScore() + "\n";
        }
        textViews[4].GetComponentInChildren<Text>().text = usernames;
        textViews[5].GetComponentInChildren<Text>().text = scores;
    }
    */

}
