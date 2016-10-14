using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	private GameObject[] buttons;
	private String[] levels;
	private User currentPlayer;
	private User[] leaderboard;

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
		leaderboard = new User[]{

		};
	}
}
