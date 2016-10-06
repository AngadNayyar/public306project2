using UnityEngine;
using System.Collections;

public class Achievement : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public static void UpdatefirstReward(){
		string gameSlotName = PlayerPrefs.GetString("CurrentGame");
		//Debug.Log(gameSlotName); 
		PlayerPrefs.SetString ("Achievement1", "achieved1"); 
		//Debug.Log(PlayerPrefs.GetString("Achievement1")); 
	}

	public static void checkFirstAchievement(){
		string gameSlotName = PlayerPrefs.GetString("CurrentGame"); 
		//Debug.Log (gameSlotName);
		//Debug.Log ("achieved:");
		//Debug.Log(PlayerPrefs.GetString("Achievement1")); 
	}

}
