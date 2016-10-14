using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class User : MonoBehaviour {
	private String username;
	private int score;
	private int highScore;
	// Implement some kind of list of achievements

	public User(int playerSlot) {
		if (PlayerPrefs.HasKey("Player" + playerSlot)) {
			username = PlayerPrefs.GetString(playerSlot);
			score = 0;
			highScore = PlayerPrefs.GetInt("HighScore" + playerSlot)
		} else {
			return null;
		}
		
	}
}
