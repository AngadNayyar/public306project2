using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/*
 * This Script controls the user data 
 * Deletes a user when the player deletes one of the 4 spaces. 
 * Updates the current user for achievements (not playing) * 
 * 
 * Charlie and the Slaughter factory - Teven Studios
 */

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

	}
}
