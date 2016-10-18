using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AttachToGameController : MonoBehaviour {

    private GameController gameController;

    public void Awake() {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
    }

    public void Pause() {
        gameController.Pause();
    }
}
