using UnityEngine;
using System.Collections;

public class StartGame : MonoBehaviour {

	private object username;

	public void toUsername() {
		UnityEngine.SceneManagement.SceneManager.LoadScene("Username");
	}

	public void submitAndStart(object usernameInput) {
		username = usernameInput;
		UnityEngine.SceneManagement.SceneManager.LoadScene("introlvl1");
	}
}
