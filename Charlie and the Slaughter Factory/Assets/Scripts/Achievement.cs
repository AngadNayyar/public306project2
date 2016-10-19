using UnityEngine;
using System.Collections;

/*
 * This Script controls the achievement data. 
 * When a user completes their first level they recieve a 'first level completed' shield.
 * This shield can be viewed on the achievements page and will be further developed to allow for multiple sheilds. 
 *
 * Charlie and the Slaughter factory - Teven Studios
 */

public class Achievement {

	private string name;

	private string description;

	private bool unlocked;

	private int points;

	private int spriteIndex;

	private GameObject achievementRef; //know which achievement to show when we earn it

	public Achievement(string name, string description, int points,  int spriteIndex, GameObject achievementRef){//constructor of Achievement
		this.name = name;
		this.description = description;
		this.unlocked = false;
		this.points = points;
		this.spriteIndex = spriteIndex;
		this.achievementRef = achievementRef;
	}

	public bool EarnAchievement(){
		if (!unlocked) {
			unlocked = true;
			return true;
		} 

		return false;
			
	}




	// Use this for initialization
	void Start () {
		Achievement myAchievement = new Achievement ("run"); //instantiating object

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public static void UpdatefirstReward(){


			
	}




}
