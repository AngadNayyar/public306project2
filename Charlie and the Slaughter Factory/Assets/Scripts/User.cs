using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class User : MonoBehaviour {
	private String username;
	private int score;
	private int highScore;
	// Implement some kind of list of achievements

	// Check that this method works with a constructor!!

	// Get the user data of a player based on their player slot.
	// If the player slot is empty return null.
	public User(int playerSlot) {
		if (PlayerPrefs.HasKey("Player" + playerSlot)) {
			username = PlayerPrefs.GetString(playerSlot);
			score = 0;
			highScore = PlayerPrefs.GetInt("HighScore" + playerSlot)
		} else {
			return null;
		}
		
	}

	// Create new user where their username and high score is known (leaderboard entry).
	public User(String name, int storedScore) {
		username = name;
		highScore = storedScore;
		score = 0;
	}
}
