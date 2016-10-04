using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour {

    void OnTriggerEnter2D()
    {
        SceneManager.LoadScene("proto_lvl1");
    }
}
