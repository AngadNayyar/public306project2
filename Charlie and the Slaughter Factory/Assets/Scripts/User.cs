using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class User {
	private string playerGameSlot;
	private string username;
	private int score;
	private int highScore;

	private bool viewedCutScene1;
	private bool viewedCutScene2;
	private bool viewedCutScene3;
	// Implement some kind of list of achievements

	// Check that this method works with a constructor!!

	// If just passed a (valid) playerSlot number: create a new user object with the stored user data.
	// If no user data is stored, create an empty user object (set with default values).

	// If passed a string name and a score, create a user object to hold this leaderboard data.

	// Note that the extra if/else statements are necessary as you cannot overload constructors in c#
	public User(string playerSlot, string name, int storedScore) {
		playerGameSlot = playerSlot;
		// If leaderboard data only:
		if (playerSlot == "") {
			username = name;
			highScore = storedScore;
			score = 0;
		} else {
			// If existing player:
			if (PlayerPrefs.HasKey(playerSlot)) {
				username = PlayerPrefs.GetString(playerSlot);
				score = 0;
				highScore = PlayerPrefs.GetInt("HighScore" + playerSlot);
				viewedCutScene1 = PlayerPrefs.GetInt("CutScene1" + playerSlot) == 1;
				viewedCutScene2 = PlayerPrefs.GetInt("CutScene2" + playerSlot) == 1;
				viewedCutScene3 = PlayerPrefs.GetInt("CutScene3" + playerSlot) == 1;
			} else {
				// If new player:
				username = name;
				PlayerPrefs.SetString(playerSlot, username);
				score = 0;
				highScore = 0;
				PlayerPrefs.SetInt("HighScore" + playerSlot, 0);
				viewedCutScene1 = false;
				viewedCutScene2 = false;
				viewedCutScene3 = false;
				PlayerPrefs.SetInt("CutScene1" + playerSlot, 0);
				PlayerPrefs.SetInt("CutScene2" + playerSlot, 0);
				PlayerPrefs.SetInt("CutScene3" + playerSlot, 0);
			}
		}
	}

	// Multiple getters and setters for provate variables.

	public string GetPlayerSlot() {
		return playerGameSlot;
	}

	public string GetUsername() {
		return username;
	}

	public int GetHighScore() {
		return highScore;
	}

	public void SetUsername(string usernameInput) {
		username = usernameInput;
	}

	public void ResetScore() {
		score = 0;
	}

	public bool hasViewedCutScene1() {
		return viewedCutScene1;
	}

	public bool hasViewedCutScene2() {
		return viewedCutScene2;
	}

	public bool hasViewedCutScene3() {
		return viewedCutScene3;
	}

	public void SetHasViewedCutScene1() {
		viewedCutScene1 = true;
	}
}
