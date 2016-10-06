using UnityEngine;
using System.Collections;

public class Achievement : MonoBehaviour {

	private static string achieved = "achieved"; 
	public SpriteRenderer spriteren; 
	public Sprite grey; 
	public Sprite reward1; 

	// Use this for initialization
	void Start () {
		 
	}
	
	// Update is called once per frame
	void Update () {
		checkFirstAchievement ();
	}

	// Method to set the playerpref variable for the player achieving the first reward - completing their first level
	// called when the player goes through a door 
	public static void UpdatefirstReward(){

		string gameSlotName = PlayerPrefs.GetString("CurrentGame");
		string playerAchieve = gameSlotName + "Achievement1"; 
		PlayerPrefs.SetString (playerAchieve, achieved); 
			
	}

	public void checkFirstAchievement(){
		spriteren = GetComponent<SpriteRenderer> (); 

		string gameSlotName = PlayerPrefs.GetString("CurrentAchievements"); 
		string playerAchieve = gameSlotName + "Achievement1"; 

		spriteren = GetComponent<SpriteRenderer>(); 

		if (PlayerPrefs.GetString (playerAchieve) == achieved) {
			//set the shield to be the image 
			spriteren.sprite = reward1; 
		} else {
			// set the image to be the greyed out image 
			spriteren.sprite = grey; 
		}
	}





}
