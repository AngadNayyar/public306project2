using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimerScript : MonoBehaviour {

    public Text timerText;
    private float time = 0.00f;
    private GameController gC;
    private bool pause;
	
    void Start() {
        gC = GameObject.Find("GameController").GetComponent<GameController>();
        pause = gC.GetPaused();
    }

	// Updates the timer text to the latest time elapsed since the level was loaded
	void Update () {
        pause = gC.GetPaused();
        if (pause == false) {
            time += Time.deltaTime;
            timerText.text = time.ToString("0.00");
            PlayerPrefs.SetFloat("endTime", time);
        }
	}

    /*
    void OnDestroy() {
        
    }
    */
}
