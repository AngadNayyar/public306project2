using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class User {
	private string username;
	private int score;
	private int highScore;
	// Implement some kind of list of achievements

	// Check that this method works with a constructor!!

	// If just passed a (valid) playerSlot number: create a new user object with the stored user data.
	// If no user data is stored, create an empty user object (set with default values).

	// If passed a string name and a score, create a user object to hold this leaderboard data.

	// Note that the extra if/else statements are necessary as you cannot overload constructors in c#
	public User(int playerSlot, string name, int storedScore) {
		// If leaderboard data only:
		if (playerSlot == 0) {
			username = name;
			highScore = storedScore;
			score = 0;
		} else {
			// If existing player:
			if (PlayerPrefs.HasKey("Player" + playerSlot)) {
				username = PlayerPrefs.GetString("Player" + playerSlot);
				score = 0;
				highScore = PlayerPrefs.GetInt("HighScore" + playerSlot);
			} else {
				// If new player:
				username = "";
				score = 0;
				highScore = 0;
			}
		}
	}

	public string GetUsername() {
		return username;
	}

	public int GetHighScore() {
		return highScore;
	}
}
