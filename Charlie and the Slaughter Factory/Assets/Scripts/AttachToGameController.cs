using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

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

    public void ThemeXmas() {
        gameController.setTheme("Xmas");
        ChangeSprite("Xmas");
    }

    public void ThemeSpace()
    {
        gameController.setTheme("Space");
        ChangeSprite("Space");

    }
    public void ThemeNormal()
    {
        gameController.setTheme("Normal");
        ChangeSprite("Normal");
    }

    public void ChangeSprite(string Theme) {
        GameObject charlie = GameObject.Find("startCharlie");
        var subSprites = Resources.LoadAll<Sprite>(Theme + "/");
        foreach (var renderer in charlie.GetComponentsInChildren<SpriteRenderer>())
        {
            string spriteName = renderer.sprite.name;
            var newSprite = Array.Find(subSprites, item => item.name == spriteName);

            if (newSprite)
                renderer.sprite = newSprite;
        }
    }
}
