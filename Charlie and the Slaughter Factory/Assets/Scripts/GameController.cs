using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	private GameObject[] buttons;
	private String[] levels;
	private User currentPlayer;
	private List<User> leaderboard;

	void Awake() {
		InitialSetUp();
	}

	void InitialSetUp() {
		// Initialise list of levels
		levels = new String[]{
        	"introlvl1",
        	"proto_lvl1",
        	"FinishedGame"
		};
		// Fetch data for leaderboard
		leaderboard = new List<User>();
		for (int i = 0; i < 10; i++) {
			leaderboard.Add(new User(PlayerPrefs.GetString("LeaderboardUsername" + count), PlayerPrefs.GetString("LeaderboardScore" + count)));
		}
	}
}
