using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneScript : MonoBehaviour {

    void OnTriggerEnter2D() {

        if (false) { //check if health bar is zero i.e. chicken died

        } else { //go to level completed screen
            SceneManager.LoadScene("CompletedLevelExit");
        }
    }
}
