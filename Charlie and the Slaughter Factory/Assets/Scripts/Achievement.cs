using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/*
 * This Script controls the achievement data. 
 * When a user completes their first level they recieve a 'first level completed' shield.
 * This shield can be viewed on the achievements page and will be further developed to allow for multiple sheilds. 
 *
 * Charlie and the Slaughter factory - Teven Studios
 */

public class Achievement {

	private string name;

	public string Name {
		get {return name;}
		set {name = value;}
	}

	private string description;

	public string Description {
		get {return description;}
		set {description = value;}
	}

	private bool unlocked;

	public bool Unlocked {
		get {return unlocked;}
		set {unlocked = value;}
	}

	private int points;

	public int Points {
		get {return points;}
		set {points = value;}
	}

	private int spriteIndex;

	public int SpriteIndex {
		get { return spriteIndex;}
		set { spriteIndex = value;}
	}

	private GameObject achievementRef;

	public GameObject AchievementRef {
		get {return achievementRef;}
		set {achievementRef = value;}
	}

 //know which achievement to show when we earn it

	public Achievement(string name, string description, int points,  int spriteIndex, GameObject achievementRef){//constructor of Achievement
		this.name = name;
		this.description = description;
		this.unlocked = false;
		this.points = points;
		this.spriteIndex = spriteIndex;
		this.achievementRef = achievementRef;
		LoadAchivement ();
	}

	public bool EarnAchievement(){
		if (!unlocked) {
			//reference between actual achievement 
			achievementRef.GetComponent<Image> ().sprite = AchievementManager.Instance.unlockedSprite;
			//unlocked = true;
			SaveAchievement (true);
			return true;
		} 

		return false;
			
	}
	//saving achievement to playprefs
	public void SaveAchievement(bool value) {
		unlocked = value; 
		int tmpPoints = PlayerPrefs.GetInt ("Points");
		PlayerPrefs.SetInt ("Points", tmpPoints += points);

		PlayerPrefs.SetInt (name, value ? 1 : 0);

		PlayerPrefs.Save ();
	}

	public void LoadAchivement(){
		unlocked = PlayerPrefs.GetInt (name) == 1 ? true : false;

		if (unlocked) {
			AchievementManager.Instance.textPoints.text = "Points: " + PlayerPrefs.GetInt ("Points");
			achievementRef.GetComponent<Image> ().sprite = AchievementManager.Instance.unlockedSprite;

		}
	}
}
