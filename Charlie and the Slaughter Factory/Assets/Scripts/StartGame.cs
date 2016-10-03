using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StartGame : MonoBehaviour {

	private string username;

	public void toUsername() {
		UnityEngine.SceneManagement.SceneManager.LoadScene("Username");
	}

	public void submitAndStart(GameObject usernameInput) {
		username = usernameInput.GetComponentInChildren<Text>().text;
		UnityEngine.SceneManagement.SceneManager.LoadScene("introlvl1");
	}
}
