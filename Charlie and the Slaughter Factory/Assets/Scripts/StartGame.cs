using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StartGame : MonoBehaviour {

	private string username;

    private void createPrefabs() {
    	PlayerPrefs.SetString("1", "CutScene1");
    	PlayerPrefs.SetString("2", "CutScene2");
    	PlayerPrefs.SetString("3", "CutScene3");
    	PlayerPrefs.SetString("4", "CutScene4");
    	PlayerPrefs.SetString("5", "CutScene5");
    	PlayerPrefs.SetString("6", "CutScene6");
    	PlayerPrefs.SetString("7", "CutScene7");
    	PlayerPrefs.SetString("8", "CutScene8");
        PlayerPrefs.SetString("9", "introlvl1");
        PlayerPrefs.SetString("10", "CompletedLevelExit");
        PlayerPrefs.SetString("11", "proto_lvl1");
        PlayerPrefs.SetString("12", "CompletedLevelExit");
        PlayerPrefs.SetString("13", "FinishedGame");
        PlayerPrefs.SetString("CurrentScene", "1");
        PlayerPrefs.SetInt("CurrentScore", 0);
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
		PlayerPrefs.SetString(PlayerPrefs.GetString("CurrentGame") + "Achieved1", "notAchieved1");
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

	public void DisplayCredits() {
		UnityEngine.SceneManagement.SceneManager.LoadScene("Credits");
	}
}
