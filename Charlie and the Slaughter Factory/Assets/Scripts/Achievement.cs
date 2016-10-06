using UnityEngine;
using System.Collections;

public class Achievement : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public static void UpdatefirstReward(){
		string gameSlotName = PlayerPrefs.GetString("CurrentGame");
		Debug.Log(gameSlotName); 
	}
}
