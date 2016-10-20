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
	private int index;

    private int[] cutScenes1 = new int[]{0,1,2,3,1,2,1,2,2};
	private string[] dialogue1 = new string[]{
        "It's a rough place out in that factory for a little chicken like you ...",
        "Who ... who are you?",
        "Charlie, I'm your ticket out of here.",
        "Take this card, it will open the doors to the outside.",
        "Aren't you coming with me?",
        "No ... I lost my leg on my last attempt. I'll only slow you down.",
        "But ...",
        "No buts Charlie. Avoid the machines and don't get caught.",
        "Remember to collect your friends along the way."
    };

    private int[] cutScenes2 = new int[]{0,1,1,0,1,1};
    private string[] dialogue2 = new string[]{
        "Oh no! Where am I? All I remember is falling ...",
        "Who's there! Wait, you're just a little chick.",
        "What are you doing down here? It's not safe!",
        "I fell, I'm trying to find my way out.",
        "Well, try heading that way, but be careful it gets pretty hot down here.",
        "If you take too long to get out of the furnace you'll burn up."
    };

    private int[] cutScenes3 = new int[]{0,0};
    private string[] dialogue3 = new string[] {
        "Huh, looks like someone left this window open.",
        "Maybe I can get out this way!"
    };

    // On awakening, save the cut scene objects before setting them to invisible so that they can be accessed later.
    void Awake() {
        index = 0;
        gameController = GameObject.Find("GameController").GetComponent<GameController>();

        cutScenes = GameObject.Find("CutScenes");
        cutSceneImages.Add(GameObject.Find("CutScene1"));
        cutSceneImages.Add(GameObject.Find("CutScene2"));
        cutSceneImages.Add(GameObject.Find("CutScene3"));
        cutSceneImages.Add(GameObject.Find("CutScene4"));
        for (int i = 0; i < cutSceneImages.Count; i++) {
            cutSceneImages[i].SetActive(false);
        }
        button = GameObject.Find("Button");
		skipbutton = GameObject.Find("Skip");
        cutScenes.SetActive(false);

        finishedGame = GameObject.Find("FinishedGame");
        if ((gameController.hasFinished() != true) & (finishedGame != null)) {
            finishedGame.SetActive(false);
        }
    }

    // When start game is called
	public void startGame() {
		gameController.PlayGame(this);
	}

    // When you walk through the door, open the finished level popup, and the cut scenes underneath (if applicable).
    void OnTriggerEnter2D(Collider2D coll){
        // Make sure that it only runs when charlie collides with the door.
        if (coll.name == "Charlie") {
            Time.timeScale = 0;
            gameController.SetPaused(true);
            Achievement.UpdatefirstReward ();
            gameController.ShowPopup(gameController.getFinishedLevel());
            startGame();
        }
    }

    // Play the cut scenes, in the order specified above, until they are finished, and then set that the user has viewed them (so they don't have to next time)
    public void PlayCutScene1() {
		
        cutScenes.SetActive(true);
        if (index != 0) {
            cutSceneImages[cutScenes1[index-1]].SetActive(false);
        }
        cutSceneImages[cutScenes1[index]].SetActive(true);
        button.GetComponentInChildren<Text>().text = dialogue1[index];

        index = index + 1;
        if (index >= dialogue1.Length) {
            gameController.getCurrentPlayer().SetHasViewedCutScene1();
        }
    }

    // Play the cut scenes, in the order specified above, until they are finished, and then set that the user has viewed them (so they don't have to next time)
    public void PlayCutScene2() {
        
        cutScenes.SetActive(true);
        if (index != 0) {
            cutSceneImages[cutScenes2[index-1]].SetActive(false);
        }
        cutSceneImages[cutScenes2[index]].SetActive(true);
        button.GetComponentInChildren<Text>().text = dialogue2[index];

        index = index + 1;
        if (index >= dialogue2.Length) {
            gameController.getCurrentPlayer().SetHasViewedCutScene2();
        }
    }

    // Play the cut scenes, in the order specified above, until they are finished, and then set that the user has viewed them (so they don't have to next time)
    public void PlayCutScene3() {
        
        cutScenes.SetActive(true);
        if (index != 0) {
            cutSceneImages[cutScenes3[index-1]].SetActive(false);
        }
        cutSceneImages[cutScenes3[index]].SetActive(true);
        button.GetComponentInChildren<Text>().text = dialogue3[index];

        index = index + 1;
        if (index >= dialogue3.Length) {
            gameController.getCurrentPlayer().SetHasViewedCutScene3();
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
