using UnityEngine;
using UnityEngine.UI;
using System.Collections;

// Interface class for game controller
public class AttachToGameController : MonoBehaviour {

    private GameController gameController;

    public void Awake() {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
    }

    public void HidePopup(GameObject panel) {
        gameController.HidePopup(panel);
    }

    public void ShowPopup(GameObject panel) {
        gameController.ShowPopup(panel);
    }

    public void SaveNewPlayer(Text username) {
        gameController.SaveNewPlayer(username);
    }

    public void SelectGameSlot(GameObject slot) {
        gameController.SelectGameSlot(slot);
    }

    public void DeleteUser() {
        gameController.DeleteUser();
    }
}
