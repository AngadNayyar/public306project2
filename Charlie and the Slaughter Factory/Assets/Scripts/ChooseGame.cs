using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ChooseGame : MonoBehaviour {

	private string gameSlotName;

	public void Start() {
		gameSlotName = PlayerPrefs.GetString(name);
		if (gameSlotName != "") {
			GetComponentInChildren<Text>().text = gameSlotName;
			//PlayerPrefs.SetString ("Achieved1", "notAchieved1"); 
		}
	}

	public void SetUpGame() {
		gameSlotName = PlayerPrefs.GetString(name);
		PlayerPrefs.SetString("CurrentGame", name);
		PlayerPrefs.Save();
		if (gameSlotName == "") {
			UnityEngine.SceneManagement.SceneManager.LoadScene("Username");
		} else {
			UnityEngine.SceneManagement.SceneManager.LoadScene(PlayerPrefs.GetString("1"));
		}
	}

	public void goToAchievements(){
		gameSlotName = PlayerPrefs.GetString(name);
		//Debug.Log(gameSlotName); 
		if (gameSlotName != ""){
			UnityEngine.SceneManagement.SceneManager.LoadScene ("Achievements"); 
		}

		//Achievement.checkFirstAchievement (); 

	}

	public void returnToGameChooser(){
		UnityEngine.SceneManagement.SceneManager.LoadScene ("GameChooser"); 
	}


}
