using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class NextLevel : MonoBehaviour {

    private GameController gameController;

    public void toPrototypeLevel()
    {
        int currentScene = int.Parse(PlayerPrefs.GetString("CurrentScene"));
        int nextScene = currentScene + 1;
        string newScene = (nextScene).ToString();
        PlayerPrefs.SetString("CurrentScene", newScene);

        // Checks if next scene is the furthest the User has gotten and if so,
        // sets that level to highestLevel in User object
        int highestLevel = gameController.getCurrentPlayer().GetHighestLevel();
        print(highestLevel);
        if (highestLevel > (nextScene)) {
            gameController.getCurrentPlayer().SetHighestLevel(nextScene);
        }
        SceneManager.LoadScene(PlayerPrefs.GetString(newScene));
    }

}
