using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StartGame : MonoBehaviour {

	private string username;

	public void toUsername() {
		UnityEngine.SceneManagement.SceneManager.LoadScene("Username");
	}

	public void setWarningText(GameObject warning) {
		if (username == "") {
			warning.GetComponentInChildren<Text>().text = "Please input a valid username.";
		}
	}

	public void submitAndStart(GameObject usernameInput) {
		username = usernameInput.GetComponentInChildren<Text>().text;
		if (username != "") {
			UnityEngine.SceneManagement.SceneManager.LoadScene("introlvl1");
		}
	}
}
