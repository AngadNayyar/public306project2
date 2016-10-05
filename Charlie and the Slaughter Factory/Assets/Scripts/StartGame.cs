using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StartGame : MonoBehaviour {

	private string username;

	public void toUsername() {
		PlayerPrefs.SetString("1", "introlvl1");
		//PlayerPrefs.SetString("2", "introlvl2");
		//PlayerPrefs.SetString("3", "introlvl3");
		//PlayerPrefs.SetString("4", "introlvl4");
		PlayerPrefs.SetString("2", "proto_lvl1");
		PlayerPrefs.SetString("3", "FinishedGame");

		PlayerPrefs.SetString("CurrentScene", "1");

		UnityEngine.SceneManagement.SceneManager.LoadScene("GameChooser");
	}

	public void setWarningText(GameObject warning) {
		if (username == "") {
			warning.GetComponentInChildren<Text>().text = "Please input a valid username.";
		}
	}

	public void submitAndStart(GameObject usernameInput) {
		username = usernameInput.GetComponentInChildren<Text>().text;
		PlayerPrefs.SetString(PlayerPrefs.GetString("CurrentGame"), username);
		PlayerPrefs.Save();
		if (username != "") {
			startGame();
		}
	}

	public void startGame() {
		UnityEngine.SceneManagement.SceneManager.LoadScene(PlayerPrefs.GetString("1"));
	}

	public void backToMain() {
		UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
	}
}
