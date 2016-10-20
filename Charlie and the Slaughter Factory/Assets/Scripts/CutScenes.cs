using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class CutScenes : MonoBehaviour {

	private GameController gameController;
	private GameObject cutScenes1;
    private GameObject cutScenes2;
    private GameObject cutScenes3;

	private GameObject button;
	private GameObject skipbutton;

	private List<GameObject> cutSceneImages1 = new List<GameObject>();
    private List<GameObject> cutSceneImages2 = new List<GameObject>();
    private List<GameObject> cutSceneImages3 = new List<GameObject>();
	private int index;

    private int[] cutScenes1Order = new int[]{0,1,2,3,1,2,1,2,2};
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

    private int[] cutScenes2Order = new int[]{0,1,1,0,1,1};
    private string[] dialogue2 = new string[]{
        "Oh no! Where am I? All I remember is falling ...",
        "Who's there! Wait, you're just a little chick.",
        "What are you doing down here? It's not safe!",
        "I fell, I'm trying to find my way out.",
        "Well, try heading that way, but be careful it gets pretty hot down here.",
        "If you take too long to get out of the furnace you'll burn up."
    };

    private int[] cutScenes3Order = new int[]{0,0};
    private string[] dialogue3 = new string[] {
        "Huh, looks like someone left this window open.",
        "Maybe I can get out this way!"
    };

    // On awakening, save the cut scene objects before setting them to invisible so that they can be accessed later.
    void Awake() {
        index = 0;
        gameController = GameObject.Find("GameController").GetComponent<GameController>();

        cutScenes1 = GameObject.Find("CutScenes1");
        cutSceneImages1.Add(GameObject.Find("CutScene1"));
        cutSceneImages1.Add(GameObject.Find("CutScene2"));
        cutSceneImages1.Add(GameObject.Find("CutScene3"));
        cutSceneImages1.Add(GameObject.Find("CutScene4"));
        for (int i = 0; i < 4; i++) {
            if (cutSceneImages1[i] != null) {
                cutSceneImages1[i].SetActive(false);
            }
        }

        cutScenes2 = GameObject.Find("CutScenes2");
        cutSceneImages2.Add(GameObject.Find("CutScene5"));
        cutSceneImages2.Add(GameObject.Find("CutScene6"));
        for (int i = 0; i < 2; i++) {
            if (cutSceneImages2[i] != null) {
                cutSceneImages2[i].SetActive(false);
            }
        }

        cutScenes3 = GameObject.Find("CutScenes3");
        cutSceneImages3.Add(GameObject.Find("CutScene7"));
        for (int i = 0; i < 1; i++) {
            if (cutSceneImages3[i] != null) {
                cutSceneImages3[i].SetActive(false);
            }
        }

        button = GameObject.Find("Button");
		skipbutton = GameObject.Find("Skip");

        if (cutScenes1 != null) {
            cutScenes1.SetActive(false);
        }
        if (cutScenes2 != null) {
            cutScenes2.SetActive(false);
        }
        if (cutScenes3 != null) {
            cutScenes3.SetActive(false);
        }

        GameObject.Find("CutScenes4").SetActive(false);

        PlayNextScene();
    }

    public void PlayNextScene() {
        if ((gameController.getCurrentLevel() == -1) & (!gameController.getCurrentPlayer().hasViewedCutScene1())) {
            PlayCutScene1();
        }
        if ((gameController.getCurrentLevel() == 3) & (!gameController.getCurrentPlayer().hasViewedCutScene2())) {
            PlayCutScene2();
        }
        if ((gameController.getCurrentLevel() == 6) & (!gameController.getCurrentPlayer().hasViewedCutScene3())) {
            PlayCutScene3();
        }
    }

    // Play the cut scenes, in the order specified above, until they are finished, and then set that the user has viewed them (so they don't have to next time)
    public void PlayCutScene1() {
        if (index >= dialogue1.Length) {
            gameController.getCurrentPlayer().SetHasViewedCutScene1();
            gameController.NextLevel();
        }
		
        cutScenes1.SetActive(true);
        if (index != 0) {
            cutSceneImages1[cutScenes1Order[index-1]].SetActive(false);
        }
        cutSceneImages1[cutScenes1Order[index]].SetActive(true);
        button.GetComponentInChildren<Text>().text = dialogue1[index];

        index = index + 1;
    }

    // Play the cut scenes, in the order specified above, until they are finished, and then set that the user has viewed them (so they don't have to next time)
    public void PlayCutScene2() {
        if (index >= dialogue2.Length) {
            gameController.getCurrentPlayer().SetHasViewedCutScene2();
            gameController.NextLevel();
        }
        
        cutScenes2.SetActive(true);
        if (index != 0) {
            cutSceneImages2[cutScenes2Order[index-1]].SetActive(false);
        }
        cutSceneImages2[cutScenes2Order[index]].SetActive(true);
        button.GetComponentInChildren<Text>().text = dialogue2[index];
    }

    // Play the cut scenes, in the order specified above, until they are finished, and then set that the user has viewed them (so they don't have to next time)
    public void PlayCutScene3() {
        if (index >= dialogue3.Length) {
            gameController.getCurrentPlayer().SetHasViewedCutScene3();
            gameController.NextLevel();
        }
        
        cutScenes3.SetActive(true);
        if (index != 0) {
            cutSceneImages3[cutScenes3Order[index-1]].SetActive(false);
        }
        cutSceneImages3[cutScenes3Order[index]].SetActive(true);
        button.GetComponentInChildren<Text>().text = dialogue3[index];
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
