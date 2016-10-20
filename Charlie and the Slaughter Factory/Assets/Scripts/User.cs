using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class User {
	private string playerGameSlot;
	private string username;
    private int score;
    private int collectables;

	//public Dictionary<string, Achievement> achievements = new Dictionary<string, Achievement> ();
	private int achievements; 
	private int achievements2; 
	private int achievements3; 

	private bool viewedCutScene1;
	private bool viewedCutScene2;
	private bool viewedCutScene3;
	// Implement some kind of list of achievements

	// Check that this method works with a constructor!!

	// If just passed a (valid) playerSlot number: create a new user object with the stored user data.
	// If no user data is stored, create an empty user object (set with default values).

	// If passed a string name and a score, create a user object to hold this leaderboard data.

	// Note that the extra if/else statements are necessary as you cannot overload constructors in c#
	public User(string playerSlot, string name, int storedScore) {
		playerGameSlot = playerSlot;
		// If existing player:
		// Get the existing player's data and set up the object
		if (PlayerPrefs.HasKey(playerSlot)) {
			username = PlayerPrefs.GetString(playerSlot);
            score = PlayerPrefs.GetInt(playerSlot + "Score");
            collectables = PlayerPrefs.GetInt(playerSlot + "TotalCollectables");
			viewedCutScene1 = PlayerPrefs.GetInt(playerSlot + "CutScene1") == 1;
			viewedCutScene2 = PlayerPrefs.GetInt(playerSlot + "CutScene2") == 1;
			viewedCutScene3 = PlayerPrefs.GetInt(playerSlot + "CutScene3") == 1;

			achievements = PlayerPrefs.GetInt (playerSlot + "achievement1"); 
			achievements2 = PlayerPrefs.GetInt (playerSlot + "achievement2"); 
			achievements3 = PlayerPrefs.GetInt (playerSlot + "achievement3"); 
			//load create achievements

		} else {
			// If new player:
			// Set up data for new player (i.e. no score and hasn't viewed cutscenes yet)
			username = name;
			PlayerPrefs.SetString(playerSlot, username);
            score = 0;
			PlayerPrefs.SetInt(playerSlot + "Score", 0);
            collectables = 0;
            PlayerPrefs.SetInt(playerSlot + "TotalCollectables", 0);
			viewedCutScene1 = false;
			viewedCutScene2 = false;
			viewedCutScene3 = false;
			PlayerPrefs.SetInt(playerSlot + "CutScene1", 0);
			PlayerPrefs.SetInt(playerSlot + "CutScene2", 0);
			PlayerPrefs.SetInt(playerSlot + "CutScene3", 0);

			PlayerPrefs.SetInt (playerSlot + "achievement1", 0); 
			PlayerPrefs.SetInt (playerSlot + "achievement2", 0); 
			PlayerPrefs.SetInt (playerSlot + "achievement3", 0); 
			achievements = 0; 
			achievements2 = 0; 
			achievements3 = 0; 

			/*
			AchievementManager.Instance.CreateAchievement("General","Saved 10 Chickens", "Chicken Saviour", 5, 0);
			AchievementManager.Instance.CreateAchievement("General","Saved 50 Chickens", "Level 900", 5, 0);
			AchievementManager.Instance.CreateAchievement("General","Saved 100 Chickens", "Press up arrow to jump", 10, 0);
			AchievementManager.Instance.CreateAchievement("General","Saved 200 Chickens", "Press up arrow to jump", 20, 0);
			AchievementManager.Instance.CreateAchievement("General","Saved 500 Chickens", "Press up arrow to jump", 50, 0);
			AchievementManager.Instance.CreateAchievement("Other","yo", "Press up arrow to jump", 5, 0);

			//going through Achievementslist and setting as false.  
			foreach (GameObject achievementList in GameObject.FindGameObjectsWithTag("AchievementList"))
			{
				achievementList.SetActive (false);
			}
			foreach (KeyValuePair<string, Achievement> entry in achievements) {
				entry.Value.SaveAchievement (false);
				Debug.Log (entry.Value.NameAchieve);
			}*/ 
		
		}
	}

	// Delete Player Data by setting the variables to the initial, and wiping the PlayerPrefs.
	public void DeletePlayer() {
		username = "";
		PlayerPrefs.DeleteKey(playerGameSlot);
		score = 0;
        PlayerPrefs.DeleteKey(playerGameSlot + "Score");
        collectables = 0;
        PlayerPrefs.DeleteKey(playerGameSlot + "TotalCollectables");
        viewedCutScene1 = false;
		viewedCutScene2 = false;
		viewedCutScene3 = false;
		PlayerPrefs.DeleteKey(playerGameSlot + "CutScene1");
		PlayerPrefs.DeleteKey(playerGameSlot + "CutScene2");
		PlayerPrefs.DeleteKey(playerGameSlot + "CutScene3");
	}

	// Multiple getters and setters for provate variables.

	public string GetPlayerSlot() {
		return playerGameSlot;
	}

    public int GetScore() {
        return score;
    }

    public void SetScore(int s) {
        score = s;
    }

    public void ResetScore()
    {
        score = 0;
    }

    public int GetCollectables()
    {
        return collectables;
    }

    public void SetCollectables(int c)
    {
        collectables = c;
    }

    public string GetUsername() {
		return username;
	}

	public void SetUsername(string usernameInput) {
		username = usernameInput;
		PlayerPrefs.SetString(playerGameSlot, usernameInput);
	}

	public bool hasViewedCutScene1() {
		return viewedCutScene1;
	}

	public bool hasViewedCutScene2() {
		return viewedCutScene2;
	}

	public bool hasViewedCutScene3() {
		return viewedCutScene3;
	}

	public void SetHasViewedCutScene1() {
		viewedCutScene1 = true;
		PlayerPrefs.SetInt(playerGameSlot + "CutScene1", 1);
	}

	public void SetHasViewedCutScene2() {
		viewedCutScene2 = true;
		PlayerPrefs.SetInt(playerGameSlot + "CutScene1", 1);
	}

	public void SetHasViewedCutScene3() {
		viewedCutScene3 = true;
		PlayerPrefs.SetInt(playerGameSlot + "CutScene1", 1);
	}

	public int GetAchievements(){
		return achievements; 
	}

	public void SetAchievements(int val){
		achievements = val; 
	} 

	public int GetAchievements2(){
		return achievements; 
	}

	public void SetAchievements2(int val){
		achievements = val; 
	}

	public int GetAchievements3(){
		return achievements; 
	}

	public void SetAchievements3(int val){
		achievements = val; 
	}
}
