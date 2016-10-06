using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimerScript : MonoBehaviour {

    public Text timerText;
    public float time = 0.00f;
	
	// Updates the timer text to the latest time elapsed since the level was loaded
	void Update () {
        time += Time.deltaTime;
        timerText.text = time.ToString("0.00");
	}

    void OnDestroy() {
        PlayerPrefs.SetFloat("endTime", time);
    }
}
