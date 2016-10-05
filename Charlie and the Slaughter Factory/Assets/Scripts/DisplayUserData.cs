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

	public void UpdateDataHighScore(int newScore) {
		string currentGame = PlayerPrefs.GetString("CurrentGame");
		int currentScore = PlayerPrefs.GetInt(currentGame + "HighScore");
		PlayerPrefs.SetInt(currentGame + "HighScore", currentScore + newScore);
	}
}
