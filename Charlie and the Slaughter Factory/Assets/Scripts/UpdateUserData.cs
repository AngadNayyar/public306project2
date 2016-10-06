using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UpdateUserData : MonoBehaviour {
	
	public void DeleteData(GameObject player) {
		PlayerPrefs.SetString(player.name, "");
		PlayerPrefs.SetString(player.name + "Achievement1", "notAchieved1"); 
		PlayerPrefs.Save();
		player.GetComponentInChildren<Text>().text = "Add new game";
	}

	public void updateCurrentPlayer(GameObject player){
		
		PlayerPrefs.SetString("CurrentAchievements", player.name);
		PlayerPrefs.Save();
		//Debug.Log( PlayerPrefs.GetString ("CurrentAchievements"+ "Achievement1")); 
	
	}
}
