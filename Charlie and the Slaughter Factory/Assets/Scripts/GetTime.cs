using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GetTime : MonoBehaviour {

    public Text timeText;
    private float time;

	// Use this for initialization
	void Start () {
        time = PlayerPrefs.GetFloat("endTime");
        timeText.text = time.ToString("0.00");
    }

}
