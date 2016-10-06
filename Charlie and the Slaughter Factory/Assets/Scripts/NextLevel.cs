using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class NextLevel : MonoBehaviour {

    public void toPrototypeLevel()
    {
        int currentScene = int.Parse(PlayerPrefs.GetString("CurrentScene"));
        Debug.Log("currentScene = " + currentScene);
        string newScene = (currentScene + 1).ToString();
        PlayerPrefs.SetString("CurrentScene", newScene);
        SceneManager.LoadScene(PlayerPrefs.GetString(newScene));
    }

}
