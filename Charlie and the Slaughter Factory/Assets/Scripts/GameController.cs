using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	// Variables set up early on (unlikely to change state)
	private static GameController gameController;
	private string[] levels = new string[]{
    //	"proto_lvl1",
    	"level_1",
    	"level_2",
    	"level_3",
	   	"level_4",
    	"level_5",
    	"level_6",
    //	"level_7",
    //	"level_8",
    	"level_9"
	};
	private User currentPlayer;
	private string gameSlot;
	private List<User> leaderboard  = new List<User>();
	private GameObject usernameInput;
	private GameObject finishedLevel;
	private GameObject pauseLevel;
	private GameObject menuMusic;
	private GameObject deathMusic;
	private GameObject pauseButton;
	private GameObject deathScreen;
    private string theme;

	// Variables that describe current state (likely to change)
	private bool isFinished = false;
	private int currentLevel = -1;
	private bool isPausable = false;
	private bool isPaused = false;

	// When the gamecontroller is initially created make sure that only the original one exists.
	// Grab references to popups that need to be manipulated by script, and then set to inactive (i.e. not visible).
	public void Awake() {
        usernameInput = GameObject.Find("UsernameInput");
		usernameInput.SetActive(false);
		finishedLevel = GameObject.Find("FinishedLevel");
		finishedLevel.SetActive(false);
		pauseLevel = GameObject.Find("Pause");
		pauseLevel.SetActive(false);
		menuMusic = GameObject.Find("MenuMusic");
		pauseButton = GameObject.Find("PauseButton");
		pauseButton.SetActive(false);
		deathScreen = GameObject.Find("DeathScreen");
		deathScreen.SetActive(false);
		deathMusic = GameObject.Find("DeathMusic");
		deathMusic.SetActive(false);
		if (gameController != null) {
			DestroyImmediate(gameObject);
		} else {
			gameController = this;
			DontDestroyOnLoad(gameObject);
		}
	}

	// Display and close the pause screen if the p or enter is pressed
	public void Update() {
		if (isPausable) {
			if ((Input.GetKeyDown(KeyCode.Return)) | (Input.GetKeyDown(KeyCode.P))) {
				Pause();
			}
		}
	}

	// Display and close the pause screen
	public void Pause() {
		if (isPaused) {
			pauseLevel.SetActive(false);
			Time.timeScale = 1;
		} else {
			pauseLevel.SetActive(true);
			Time.timeScale = 0;
		}
		isPaused = !isPaused;
	}

	// Cycle through each game slot button and check if a username exists for this slot: if it does, set the username as the text.
	// Should be called whenever the user asks to see available game slots.
	public void UpdateGameSlots() {
		for (int i = 1; i < 5; i++) {
			GameObject player = GameObject.Find("Player" + i);
			if (PlayerPrefs.HasKey("Player" + i)) {
				player.GetComponentInChildren<Text>().text = PlayerPrefs.GetString("Player" + i);
			}
		}
	}

	// Set up the data for the leaderboard
	public List<User> SetUpLeaderboard() {
        //Get all scores of all players
		for (int i = 0; i < 4; i++) {
            User newUser = new User("Player" + i, PlayerPrefs.GetString("Player" + i), PlayerPrefs.GetInt("Player" + i + "Score"));
            //check username is not empty(empty player slot) - don't add if empty
            if (newUser.GetUsername() != "")
            {
                leaderboard.Add(new User("Player" + i, PlayerPrefs.GetString("Player" + i), PlayerPrefs.GetInt("Player" + i + "Score")));
            }
		}

        int indexOfMax = 0;
        int highestScore = leaderboard[0].GetScore();
        int score;
        int numUsers = leaderboard.Count;
        List<User> leaderboardSorted = new List<User>();

        //sort the users by their scores from largest to smallest
        
        //loop through the whole list and get the highest
        //score - end loop when smallest score is left
        for (int i = 0; i < numUsers - 1; i++) {
            for (int j = 0; j < leaderboard.Count; j++) {
                score = leaderboard[j].GetScore();
                if (score > highestScore) {
                    indexOfMax = j;
                    highestScore = score;
                }
            }
            //add the user with the next highest score to the new list
            //and remove them from the original list
            leaderboardSorted.Add(leaderboard[indexOfMax]);
            leaderboard.RemoveAt(indexOfMax);
            //reset max's
            indexOfMax = 0;
            highestScore = leaderboard[0].GetScore();
        }
        
        //add the last remaining and lowest scoring user to the sorted list
        leaderboardSorted.Add(leaderboard[0]);
        
        //return the sorted leaderboard
        return leaderboardSorted;
	}

	/*
    // Update the strings contained in the leaderboard.
	public void UpdateLeaderboardView(GameObject panel) {
		Text[] textViews = panel.GetComponentsInChildren<Text>();
		panel.SetActive(true);
		string usernames = "";
		string scores = "";
		for (int i = 0; i < leaderboard.Count; i++) {
			usernames = usernames + (i+1) + ". " + leaderboard[i].GetUsername() + "\n";
			scores = scores + leaderboard[i].GetHighScore() + "\n";
		}
		textViews[4].GetComponentInChildren<Text>().text = usernames;
		textViews[5].GetComponentInChildren<Text>().text = scores;
	}
    */

	// Delete current User Data, and go back to the main menu (with popup visible for picking slot).
	public void DeleteUser() {
		currentPlayer.DeletePlayer();
		UnityEngine.SceneManagement.SceneManager.LoadScene("Start");
	}

	// Show the supplied popup.
	public void ShowPopup(GameObject panel) {
		panel.SetActive(true);
		if (panel.name == "Leaderboard") {
			//UpdateLeaderboardView(panel);
		}
		if (panel.name == "PickPlayer") {
			UpdateGameSlots();
		}
	}

	// Hide the supplied popup
	public void HidePopup(GameObject panel) {
		panel.SetActive(false);
		if (panel.name == "FinishedLevel") {
			StartGame();
		}
	}

	// If the user selects a game slot, check if it's initialised. If not, set up the new user and then display the player's data page.
	public void SelectGameSlot(GameObject slot) {
		gameSlot = slot.name;
		// If the game slot the user selected has not yet been initialised, ask for a username:
		if (PlayerPrefs.GetString(slot.name) == "") {
			usernameInput.SetActive(true);
			usernameInput.GetComponentInChildren<InputField>().text = "";
			UpdateGameSlots();
		} else {
			// Otherwise go straight to the player's data page.
			// Initialise the user currently playing.
			currentPlayer = new User(gameSlot, PlayerPrefs.GetString(gameSlot), PlayerPrefs.GetInt(gameSlot + "Score"));
			UnityEngine.SceneManagement.SceneManager.LoadScene("PlayerData");
		}
	}

	// Create a new user (and set at the current player) based on the username (as long as the username is valid).
	public void SaveNewPlayer(Text username) {
		if (username.text == "") {
			GameObject.Find("WarningText").GetComponentInChildren<Text>().text = "Please input a valid username.";
		} else {
			// Create new user object.
			currentPlayer = new User(gameSlot, username.text, 0);
			usernameInput.SetActive(false);
			UnityEngine.SceneManagement.SceneManager.LoadScene("PlayerData");
		}
	}

	// Start game, based on data to do with the current user.
	public void StartGame() {
		if (isFinished) {
			isFinished = false;
			currentPlayer.ResetScore();
		}

		menuMusic.SetActive(false);
		deathMusic.SetActive(false);

		pauseButton.SetActive(false);
		
		// If the user hasn't seen the cut scenes yet, play them.
		if ((currentLevel == -1) & (!currentPlayer.hasViewedCutScene1())) {
			UnityEngine.SceneManagement.SceneManager.LoadScene("CutScenes");
			return;
		}
		if (currentLevel == -1) {
			NextLevel();
			return;
		}
		if ((levels[currentLevel] == "level_3") & (!currentPlayer.hasViewedCutScene2())) {
			UnityEngine.SceneManagement.SceneManager.LoadScene("CutScenes");
			return;
		}
		if ((levels[currentLevel] == "level_6") & (!currentPlayer.hasViewedCutScene3())) {
			UnityEngine.SceneManagement.SceneManager.LoadScene("CutScenes");
			return;
		}
		if (levels[currentLevel] == "level_9") {
			UnityEngine.SceneManagement.SceneManager.LoadScene("CutScenes");
			return;
		}
		NextLevel();
	}

	// Display Death popup.
	public void PlayerDied() {
		isFinished = true;
		deathScreen.SetActive(true);
		deathMusic.SetActive(true);
	}

	// If the player dies and want to continue, reset their score and run the game from the level they were on.
	public void TryAgain() {
		Time.timeScale = 1;
		currentPlayer.ResetScore();
		deathScreen.SetActive(false);
		deathMusic.SetActive(false);
		UnityEngine.SceneManagement.SceneManager.LoadScene(levels[currentLevel]);
	}

	// Play the next level, or if all levels have been finished, display the finish screen.
	public void NextLevel() {
		Time.timeScale = 1;
		// If the player finishes, make it so they reset from the beginning.
		if (currentLevel >= (levels.Length-1)) {
			currentLevel = -1;
			isPaused = false;
			menuMusic.SetActive(true);
			isFinished = true;
			isPausable = false;
			pauseButton.SetActive(false);
			UnityEngine.SceneManagement.SceneManager.LoadScene("PlayerData");
		} else {
			isPaused = false;
			menuMusic.SetActive(false);
			isPausable = true;
			currentLevel = currentLevel + 1;
            CheckSetHighestLevel();
            UnityEngine.SceneManagement.SceneManager.LoadScene(levels[currentLevel]);
			pauseButton.SetActive(true);
		}
	}

	public void GoToMainMenu() {
		currentLevel = -1;
		UnityEngine.SceneManagement.SceneManager.LoadScene("Start");
	}

    // Checks if next scene is the furthest the User has gotten and if so,
    // sets that level to highestLevel in User object
    public void CheckSetHighestLevel() {
        int highestLevel = gameController.getCurrentPlayer().GetHighestLevel();
        if (highestLevel <= (currentLevel + 1))
        {
            gameController.getCurrentPlayer().SetHighestLevel(currentLevel + 1);
        }
    }

	// Getters and setters
	public bool hasFinished() {
		return isFinished;
	}

	public User getCurrentPlayer() {
		return currentPlayer;
	}

	public string getCurrentLevel() {
		if (currentLevel == -1) {
			return null;
		}
		return levels[currentLevel];
	}

    public void setCurrentLevel(int level)
    {
        currentLevel = level;
    }

	public GameObject getFinishedLevel() {
		return finishedLevel;
	}

    public bool GetPaused()
    {
        return isPaused;
    }

    public void SetPaused(bool pause)
    {
        isPaused = pause;
    }

    public string getTheme()
    {
        return theme;
    }

    public void setTheme(string newTheme) {
        theme = newTheme;
    }
}
