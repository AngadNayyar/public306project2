using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class User {
	private string playerGameSlot;
	private string username;
    private int score;
    private int collectables;

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
}
