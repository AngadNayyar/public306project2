using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StartGame : MonoBehaviour {

	private string username;

    private void createPrefabs() {
        PlayerPrefs.SetString("1", "introlvl1");
        PlayerPrefs.SetString("2", "CompletedLevelExit");
        PlayerPrefs.SetString("3", "proto_lvl1");
        PlayerPrefs.SetString("4", "FinishedGame");
        PlayerPrefs.SetString("CurrentScene", "1");
    }

	public void toUsername() {
        createPrefabs();
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
        createPrefabs();
        UnityEngine.SceneManagement.SceneManager.LoadScene(PlayerPrefs.GetString("1"));
	}

	public void backToMain() {
		UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
	}
}
