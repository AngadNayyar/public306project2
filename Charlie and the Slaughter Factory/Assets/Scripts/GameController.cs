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
		for (int i = 0; i < 10; i++) {
			leaderboard.Add(new User(0, PlayerPrefs.GetString("LeaderboardUsername" + i), PlayerPrefs.GetInt("LeaderboardScore" + i)));
		}
	}

	public void CreateStartMenu() {
		
	}

	public void ShowPopup(GameObject panel) {
		panel.SetActive(true);
	}

	public void HidePopup(GameObject panel) {
		panel.SetActive(false);
	}
}
