using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class StartGame : MonoBehaviour {

	private GameController gameController;
	private GameObject cutScenes;
	private GameObject button;
	private GameObject skipbutton;
    private GameObject finishedGame;
	private List<GameObject> cutSceneImages = new List<GameObject>();
	private int[] cutScenes1 = new int[]{0,1,2,3,1,2,1,2};
	private int index;
	private string[] dialogue = new string[]{
        "It's a rough place out in that factory for a little chicken like you ...",
        "Who ... who are you?",
        "Charlie, I'm your ticket out of here.",
        "Take this card, it will open the doors to the outside.",
        "Aren't you coming with me?",
        "No ... I lost my leg on my last attempt. I'll only slow you down.",
        "But ...",
        "No buts Charlie. Avoid the machines and don't get caught."
    };

    // On awakening, save the cut scene objects before setting them to invisible so that they can be accessed later.
    void Awake() {
        index = 0;
        gameController = GameObject.Find("GameController").GetComponent<GameController>();

        cutScenes = GameObject.Find("CutScenes");
        cutSceneImages.Add(GameObject.Find("CutScene1"));
        cutSceneImages.Add(GameObject.Find("CutSceneCharlie"));
        cutSceneImages.Add(GameObject.Find("CutSceneOldChicken"));
        cutSceneImages.Add(GameObject.Find("CutSceneOldChickenCard"));
        GameObject.Find("CutScene1").SetActive(false);
        GameObject.Find("CutSceneCharlie").SetActive(false);
        GameObject.Find("CutSceneOldChicken").SetActive(false);
        GameObject.Find("CutSceneOldChickenCard").SetActive(false);
        button = GameObject.Find("Button");
		skipbutton = GameObject.Find("Skip");
        cutScenes.SetActive(false);

        finishedGame = GameObject.Find("FinishedGame");
        if (gameController.hasFinished() != true) {
            finishedGame.SetActive(false);
        }
    }

    // When start game is called
	public void startGame() {
		gameController.PlayGame(this);
	}

    // Play the cut scenes, in the order specified above, until they are finished, and then set that the user has viewed them (so they don't have to next time)
    public void PlayCutScene1() {
		
        cutScenes.SetActive(true);
        if (index != 0) {
            cutSceneImages[cutScenes1[index-1]].SetActive(false);
        }
        cutSceneImages[cutScenes1[index]].SetActive(true);
        button.GetComponentInChildren<Text>().text = dialogue[index];

        index = index + 1;
        if (index >= dialogue.Length) {
            gameController.getCurrentPlayer().SetHasViewedCutScene1();
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
}
