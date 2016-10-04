using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UpdateUserData : MonoBehaviour {

	public void DeleteData(GameObject player) {
		PlayerPrefs.SetString(player.name, "");
		PlayerPrefs.Save();
		player.GetComponentInChildren<Text>().text = "Add new game";
	}
}
