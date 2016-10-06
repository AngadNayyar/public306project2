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

	public int UpdateCurrentScore(int newScore) {
		int currentScore = PlayerPrefs.GetInt("CurrentScore");
        int updatedScore = currentScore + newScore;
        PlayerPrefs.SetInt("CurrentScore", updatedScore);
        UpdateDataHighScore();
        return updatedScore;
    }

	public static void UpdateDataHighScore() {
		int newScore = PlayerPrefs.GetInt("CurrentScore");
		string currentGame = PlayerPrefs.GetString("CurrentGame");
		int highScore = PlayerPrefs.GetInt(currentGame + "HighScore");
		if (highScore < newScore) {
			PlayerPrefs.SetInt(currentGame + " HighScore", newScore);
		}
	}
		
}
