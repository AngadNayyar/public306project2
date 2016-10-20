using UnityEngine;
using System.Collections;

public class RespawnFallingObjects : MonoBehaviour {

	public GameObject fallingObj; 

	// Use this for initialization
	void Start () {
		Instantiate (fallingObj);
	}
}
