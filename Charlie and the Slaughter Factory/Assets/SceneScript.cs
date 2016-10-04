using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneScript : MonoBehaviour {



    void OnTriggerEnter2D() {
        SceneManager.LoadScene("CompletedLevelExit");
    }
}
