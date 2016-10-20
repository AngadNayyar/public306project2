using UnityEngine;
using UnityEngine.UI;
using System.Collections;

// Interface class for game controller
public class LevelSelector : MonoBehaviour
{

    private GameController gameController;
    private int highestLevelUnlocked;

    private Button[] levels;

    public void Awake()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
        highestLevelUnlocked = gameController.getCurrentPlayer().GetHighestLevel();
        levels = GameObject.Find("ChooseLevel").GetComponentsInChildren<Button>();

        for (int i = highestLevelUnlocked+3; i < levels.Length; i++)
        {
            if (levels[i].name != "BackButton") {
                levels[i].interactable = false;
            }
        }
    }

	public void SelectLevel(int level)
    {
        gameController.setCurrentLevel(level);
        gameController.StartGame();
    }
}
