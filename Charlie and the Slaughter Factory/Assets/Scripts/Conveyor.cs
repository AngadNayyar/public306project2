using UnityEngine;
using System.Collections;


/*
 * This script controls conveyor belt mechanics. 
 * When charlie touches the conveyor, his speed increases.  
 * 
 * To use this script, attach it to the conveyor belt platform object, which will need a collision box.  
 *  
 * Charlie and the Slaughter factory - Teven Studios
 */

public class Conveyor : MonoBehaviour {

	// set the speed for the conveyor
	public int conveyorSpeed = 5; 
	GameObject player;  // Reference to Charlie
	Rigidbody2D playerBody;
	public bool movementRight = true; 


	// Use this for initialization
	void Start () {
		// Get the player rigid body
		player = GameObject.FindGameObjectWithTag("Player");
		playerBody = player.GetComponent<Rigidbody2D>();
	}

	// While charlie is on the conveyor add a speed to the right 
	void OnCollisionStay2D(Collision2D other){
		if (other.gameObject.CompareTag("Player")){
			if (movementRight) {
				playerBody.velocity = playerBody.velocity + Vector2.right * conveyorSpeed;
			}  else {
				playerBody.velocity = playerBody.velocity + Vector2.left * conveyorSpeed; 
				Debug.Log (playerBody.velocity); 
			}  
		}

	}
}

