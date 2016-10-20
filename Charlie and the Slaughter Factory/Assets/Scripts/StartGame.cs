using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class StartGame : MonoBehaviour {

	private GameController gameController;
    private GameObject finishedGame;

    // On awakening, check whether the player has finished the game.
    void Awake() {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
        finishedGame = GameObject.Find("FinishedGame");
        Debug.Log(gameController.hasFinished());
        Debug.Log(finishedGame);
        if ((gameController.hasFinished() != true) & (finishedGame != null)) {
            finishedGame.SetActive(false);
        }
    }

    // Hide supplied popup
    public void HidePopup(GameObject panel) {
        panel.SetActive(false);
    }

    // Show popup
    public void ShowPopup(GameObject panel) {
        gameController.ShowPopup(panel);
    }

	// Skip in video
	public void nextLevel() {
		gameController.NextLevel();
	}

    public void startGame() {
        gameController.StartGame();
    }
}
