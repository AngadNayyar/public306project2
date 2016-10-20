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
	//fields in the object as follows
	private User player;
	public User Player {
		get {return player;}
		set {player = value;}
	}

	private string playerName;
	public string PlayerName {
		get {return playerName;}
		set {playerName = value;}
	}
		
	private string nameAchieve;
	public string NameAchieve {
		get {return nameAchieve;}
		set {nameAchieve = value;}
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
	public Achievement(User player, string playerName, string nameAchieve, string description, int points,  int spriteIndex, GameObject achievementRef){//constructor of Achievement
		this.player = player; 
		this.playerName = playerName;
		this.nameAchieve = nameAchieve;
		this.description = description;
		this.unlocked = false;
		this.points = points;
		this.spriteIndex = spriteIndex;
		this.achievementRef = achievementRef;
	}

	public void EarnAchievement(){
		//changing the achievement sprite to be gold and unlocked
		achievementRef.GetComponent<Image> ().sprite = AchievementManager.Instance.unlockedSprite;
	}
}
