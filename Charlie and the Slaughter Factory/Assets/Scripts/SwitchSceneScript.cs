using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SwitchSceneScript : MonoBehaviour {

    private GameController gameController;

    void Awake() {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
    }

    // When you walk through the door, open the finished level popup
    void OnTriggerEnter2D(Collider2D coll){
        // Make sure that it only runs when charlie collides with the door.
        if (coll.name == "Charlie") {
            Time.timeScale = 0;
            gameController.SetPaused(true);
            gameController.ShowPopup(gameController.getFinishedLevel());
			GameObject.Find("Stage1BGSound").SetActive(false);

        }
    }
}
