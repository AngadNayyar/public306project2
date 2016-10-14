using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DisplayPlayerData : MonoBehaviour {
	private GameController gameController;

    void Awake() {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
        GameObject.Find("Username").GetComponentInChildren<Text>().text = gameController.currentPlayer.GetUsername();
    }

    public void GoToMainMenu() {
    	gameController.GoToMainMenu();
    }
}