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
        levels = GameObject.Find("Levels").GetComponentsInChildren<Button>();

        Debug.Log(highestLevelUnlocked);

        for (int i = highestLevelUnlocked+2; i < levels.Length; i++)
        {
            Debug.Log(i);
            Debug.Log(levels[i]);
            levels[i].interactable = false;
        }
    }

	public void SelectLevel(int level)
    {
        gameController.setCurrentLevel(level);
        gameController.StartGame();
    }
}
