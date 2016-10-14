using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class StartGame : MonoBehaviour {

	private GameController gameController;
	private GameObject cutScenes;
	private GameObject button;
	private List<GameObject> cutSceneImages = new List<GameObject>();
	private int[] cutScenes1;
	private int index = 0;
	private string[] dialogue;

    void Awake() {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
        cutScenes = GameObject.Find("CutScenes");
        button = GameObject.Find("Button");
        cutSceneImages.Add(GameObject.Find("CutScene1"));
        GameObject.Find("CutScene1").SetActive(false);
        cutSceneImages.Add(GameObject.Find("CutSceneCharlie"));
        GameObject.Find("CutSceneCharlie").SetActive(false);
        cutSceneImages.Add(GameObject.Find("CutSceneOldChicken"));
        GameObject.Find("CutSceneOldChicken").SetActive(false);
        cutSceneImages.Add(GameObject.Find("CutSceneOldChickenCard"));
        GameObject.Find("CutSceneOldChickenCard").SetActive(false);
        cutScenes.SetActive(false);
        cutScenes1 = new int[]{0,1,2,3,1,2,1,2};
        dialogue = new string[]{
        	"It's a rough place out in that factory for a little chicken like you ...",
        	"Who ... who are you?",
        	"Charlie, I'm your ticket out of here.",
        	"Take this card, it will open the doors to the outside.",
        	"Aren't you coming with me?",
        	"No ... I lost my leg on my last attempt. I'll only slow you down.",
        	"But ...",
        	"No buts Charlie. Avoid the machines and don't get caught."
        };
    }

	public void startGame() {
		gameController.PlayGame();
		cutScenes.SetActive(true);
		if (index != 0) {
			cutSceneImages[cutScenes1[index-1]].SetActive(false);
		}
		cutSceneImages[cutScenes1[index]].SetActive(true);
		button.GetComponentInChildren<Text>().text = dialogue[index];
		index = index + 1;
		if (index > cutSceneImages.Count) {
			gameController.currentPlayer.SetHasViewedCutScene1();
		}
	}
}
