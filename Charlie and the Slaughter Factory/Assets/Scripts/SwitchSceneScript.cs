using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SwitchSceneScript : MonoBehaviour {

     void OnTriggerEnter2D()
    {
        Debug.Log(PlayerPrefs.GetString("CurrentScene"));
		Achievement.UpdatefirstReward ();
    	int currentScene = int.Parse(PlayerPrefs.GetString("CurrentScene"));
    	string newScene = (currentScene + 1).ToString();
    	PlayerPrefs.SetString("CurrentScene", newScene);
        PlayerPrefs.Save();
        SceneManager.LoadScene(PlayerPrefs.GetString(newScene));
    }

    public void OnClick() {
        Debug.Log(PlayerPrefs.GetString("CurrentScene"));
        int currentScene = int.Parse(PlayerPrefs.GetString("CurrentScene"));
    	string newScene = (currentScene + 1).ToString();
    	PlayerPrefs.SetString("CurrentScene", newScene);
        PlayerPrefs.Save();
        SceneManager.LoadScene(PlayerPrefs.GetString(newScene));
    }
}
