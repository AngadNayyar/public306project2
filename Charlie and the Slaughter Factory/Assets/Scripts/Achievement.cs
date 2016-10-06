using UnityEngine;
using System.Collections;

/*
 * This Script controls the achievement data. 
 * When a user completes their first level they recieve a 'first level completed' shield.
 * This shield can be viewed on the achievements page and will be further developed to allow for multiple sheilds. 
 *
 * Charlie and the Slaughter factory - Teven Studios
 */

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

	// Method to set the playerpref variable for the player achieving the first reward - completing their first level.
	// This method is called when the player goes through a door (from the switch scene script)
	public static void UpdatefirstReward(){

		string gameSlotName = PlayerPrefs.GetString("CurrentGame");
		string playerAchieve = gameSlotName + "Achievement1"; 
		PlayerPrefs.SetString (playerAchieve, achieved); 
			
	}

	// This method checks whether the user has completed their first level, and it used to determine whether the 
	// shield should be displayed or whether it should be greyed out. 
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
