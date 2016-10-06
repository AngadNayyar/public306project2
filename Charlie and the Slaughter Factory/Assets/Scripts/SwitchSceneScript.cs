using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SwitchSceneScript : MonoBehaviour {

    void OnTriggerEnter2D()
    {
		Achievement.UpdatefirstReward ();
    	int currentScene = int.Parse(PlayerPrefs.GetString("CurrentScene"));
        //Debug.Log("currentScene = " + currentScene);
    	string newScene = (currentScene + 1).ToString();
    	PlayerPrefs.SetString("CurrentScene", newScene);
        SceneManager.LoadScene(PlayerPrefs.GetString(newScene));
    }
}
