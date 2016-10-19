using UnityEngine;
using System.Collections;

/*
 * This Script controls the pop ups in level one for introducting the game mechanics  
 *
 * The pop up sprite is set through the inspector to be the image of the popup desired.  
 *
 * Charlie and the Slaughter factory - Teven Studios
 */
public class TutorialPopups : MonoBehaviour {

	public SpriteRenderer popup; 


	// Use this for initialization
	void Start () {
		popup.enabled = false; 
	}


	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.CompareTag("Player")){
			popup.enabled = true; 
		} 
	}


}
