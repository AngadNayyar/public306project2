using UnityEngine;
using System;

public class ThemeSkin : MonoBehaviour
{

    private GameController gameController;

    void Start()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
        var subSprites = Resources.LoadAll<Sprite>(gameController.getTheme() + "/");

        foreach (var renderer in GetComponentsInChildren<SpriteRenderer>())
        {
            string spriteName = renderer.sprite.name;
            var newSprite = Array.Find(subSprites, item => item.name == spriteName);

            if (newSprite)
                renderer.sprite = newSprite;
        }
    }

}