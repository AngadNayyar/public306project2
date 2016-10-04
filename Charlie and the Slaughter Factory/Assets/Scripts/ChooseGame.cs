using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ChooseGame : MonoBehaviour {

	private string gameSlotName;

	public void Start() {
		gameSlotName = PlayerPrefs.GetString(name);
		if (gameSlotName != "") {
			GetComponentInChildren<Text>().text = gameSlotName;
		}
	}

	public void SetUpGame() {
		PlayerPrefs.SetString("CurrentGame", name);
		PlayerPrefs.Save();
		if (gameSlotName == "") {
			UnityEngine.SceneManagement.SceneManager.LoadScene("Username");
		} else {
			UnityEngine.SceneManagement.SceneManager.LoadScene("introlvl1");
		}
	}
}
