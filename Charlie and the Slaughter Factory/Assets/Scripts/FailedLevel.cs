using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FailedLevel : MonoBehaviour {

	public void Start() {
		int score = PlayerPrefs.GetInt("CurrentScore");
		gameObject.GetComponent<Text>().text = "Score: " + score;
        Debug.Log(score);
	}
}
