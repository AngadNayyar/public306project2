using UnityEngine;
using System.Collections;

public class TutorialPopups : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.CompareTag("Player")){


			if (this.gameObject.name == "JumpTrigger") {
				Debug.Log ("Jump"); 

			} else if (this.gameObject.name == "SlideTrigger") {
				Debug.Log ("Slide"); 


			} else if (this.gameObject.name == "DoubleJumpTrigger") {
				Debug.Log ("Double jump"); 

			}

		} 
	}


}
