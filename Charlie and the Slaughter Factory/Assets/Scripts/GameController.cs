using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	private GameObject[] buttons;
	private string[] levels;
	private User currentPlayer;
	private List<User> leaderboard;

	private GameObject usernameInput;

	public void Awake() {
		usernameInput = GameObject.Find("UsernameInput");
		UpdateUsernames();
		usernameInput.SetActive(false);
		DontDestroyOnLoad(transform.gameObject);
		InitialSetUp();
		CreateStartMenu();
	}

	// Cycle through each game slot button and check if a username exists for this slot: if it does, set the username as the text.
	public void UpdateUsernames() {
		for (int i = 1; i < 5; i++) {
			GameObject player = GameObject.Find("Player" + i);
			if (PlayerPrefs.GetString("Player" + i) != "") {
				player.GetComponentInChildren<Text>().text = PlayerPrefs.GetString("Player" + i);
			}
		}
		GameObject.Find("PickPlayer").SetActive(false);
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
			leaderboard.Add(new User("", PlayerPrefs.GetString("LeaderboardUsername" + i), PlayerPrefs.GetInt("LeaderboardScore" + i)));
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

	public void SelectGameSlot(GameObject gameSlot) {
		currentPlayer = new User(gameSlot.name, "", 0);
		// If the game slot the user selected has not yet been initialised, ask for a username:
		if (PlayerPrefs.GetString(currentPlayer.GetPlayerSlot()) == "") {
			usernameInput.SetActive(true);
		} else {
			UnityEngine.SceneManagement.SceneManager.LoadScene("PlayerData");
		}
	}

	public void ShowPlayerData(Text usernameInput) {
		Debug.Log(transform.ToString());
		currentPlayer.SetUsername(usernameInput.text);
		if (usernameInput.text == "") {
			GameObject.Find("WarningText").GetComponentInChildren<Text>().text = "Please input a valid username.";
		} else {
			UnityEngine.SceneManagement.SceneManager.LoadScene("PlayerData");
		}
	}
}
