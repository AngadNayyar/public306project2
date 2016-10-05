using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DisplayUserData : MonoBehaviour {

	public void Start() {
		int highScore = PlayerPrefs.GetInt(name);
		if (highScore != 0) {
			gameObject.GetComponent<Text>().text = "High Score: " + highScore;
		}
	}

	public void UpdateCurrentScore(int newScore) {
		int currentScore = PlayerPrefs.GetInt("CurrentScore");
		PlayerPrefs.SetInt("CurrentScore", currentScore + newScore);
	}

	public void UpdateDataHighScore(int newScore) {
		string currentGame = PlayerPrefs.GetString("CurrentGame");
		int currentScore = PlayerPrefs.GetInt(currentGame + "HighScore");
		if (currentScore < newScore) {
			PlayerPrefs.SetInt(currentGame + "HighScore", currentScore + newScore);
		}
	}
}
