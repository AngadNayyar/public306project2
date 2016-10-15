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
        Debug.Log(coll.name);
        // Make sure that it only runs when charlie collides with the door.
        if (coll.name == "Charlie") {
            Achievement.UpdatefirstReward ();
            gameController.ShowPopup(gameController.getFinishedLevel());
        }
    }
}
