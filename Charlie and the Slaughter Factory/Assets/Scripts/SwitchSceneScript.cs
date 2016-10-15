using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SwitchSceneScript : MonoBehaviour {

    private GameController gameController;

    void Awake() {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
    }

    void OnTriggerEnter2D(){
		Achievement.UpdatefirstReward ();
        gameController.NextLevel();
    }
}
