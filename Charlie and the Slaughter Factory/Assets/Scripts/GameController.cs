using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	private GameObject[] buttons;
	private string[] levels;
	private User currentPlayer;
	private List<User> leaderboard;

	public void Awake() {
		DontDestroyOnLoad(transform.gameObject);
		InitialSetUp();
		CreateStartMenu();
	}

	public void InitialSetUp() {
		// Initialise list of levels
		levels = new string[]{
        	"introlvl1",
        	"proto_lvl1",
        	"FinishedGame"
		};
		// Fetch data for leaderboard
		leaderboard = new List<User>();
		PlayerPrefs.SetString("LeaderboardUsername1", "My name is");
		PlayerPrefs.SetInt("LeaderboardScore1", 2);
		PlayerPrefs.Save();
		for (int i = 1; i < 11; i++) {
			leaderboard.Add(new User(0, PlayerPrefs.GetString("LeaderboardUsername" + i), PlayerPrefs.GetInt("LeaderboardScore" + i)));
		}
	}

	public void UpdateLeaderboardView(GameObject panel) {
		Text[] textViews = panel.GetComponentsInChildren<Text>();
		panel.SetActive(true);
		string usernames = "";
		string scores = "";
		for (int i = 0; i < leaderboard.Count; i++) {
			usernames = usernames + (i+1) + ". " + leaderboard[i].GetUsername() + "\n";
			scores = scores + leaderboard[i].GetHighScore() + "\n";
		}
		textViews[4].GetComponentInChildren<Text>().text = usernames;
		textViews[5].GetComponentInChildren<Text>().text = scores;
	}

	public void CreateStartMenu() {
		
	}

	public void ShowPopup(GameObject panel) {
		if (panel.name == "Leaderboard") {
			UpdateLeaderboardView(panel);
		}
		panel.SetActive(true);
	}

	public void HidePopup(GameObject panel) {
		panel.SetActive(false);
	}
}
