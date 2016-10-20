using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GetTime : MonoBehaviour {

    public Text timeText;
    private float time;

	// set the text for the timer label as the time taken to complete the level
	void Update () {
        time = PlayerPrefs.GetFloat("endTime");
        timeText.text = time.ToString("0.00");
        
    }

}
