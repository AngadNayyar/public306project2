using UnityEngine;
using System.Collections;

/*
 * This Script controls the mechanics of the crusher.
 * To use a crusher use a crusher prefab 
 * 
 * To make the crusher go faster change the speed in the inspector 
 *
 * Charlie and the Slaughter factory - Teven Studios
 */

public class CrusherMotion : MonoBehaviour {

	PlayerHealth playerHealth;  // Reference to the Charlie's health.
	PlayerScript playerScript; //Reference to Charlie's movement controls
	GameObject player;  // Reference to Charlie
	Rigidbody2D rigidBody;

	Rigidbody2D rb2d; //reference to the crusher 
	public float velocity = 2f; // speed of the crusher motion
	private bool swap = false; 


	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
		playerHealth = player.GetComponent<PlayerHealth>();
		rigidBody = player.GetComponent<Rigidbody2D>();
		rb2d = GetComponent<Rigidbody2D> (); 
	}
	
	// Update is called once per frame
	void Update () {
		// update the velocity of crusher 
		rb2d.velocity = new Vector2(rb2d.velocity.x, velocity);

	}


	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.CompareTag("ground")) {
			// swap the direction of the crusher motion when hit ground or ceiling 
			swap = !swap;
			velocity *= -1; 
			Vector3 theScale = transform.localScale;
			theScale.x *= -1;
			transform.localScale = theScale;
		}
	}
}

