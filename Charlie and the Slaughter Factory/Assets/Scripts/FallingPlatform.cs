using UnityEngine;
using System.Collections;

/*
 * This script controls the falling platforms
 * 
 * To use this script, attach it to the platform. You will also need to create a RigidBody2D 
 * and set to is Kinematic, as well as attaching a BoxCollider2D 
 * For disappearing ensure that the ground below has tag ground, or insert the tag of the objects below in the destroy if statement 
 *  
 * Charlie and the Slaughter factory - Teven Studios
 */ 

public class FallingPlatform : MonoBehaviour {

	// Sets the time from the chicken landing on the platform till falling 
	public float fallDelay = 1f;

	private Rigidbody2D rb2d;

	// Get the rigidbody2D on start 
	void Awake()
	{
		rb2d = GetComponent<Rigidbody2D>();
	}


	// If the player is the colliding object then make the platform fall. 
	void OnCollisionEnter2D (Collision2D other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			Invoke ("Fall", fallDelay);
		}
		if (other.gameObject.CompareTag("ground")  ||  (other.gameObject.CompareTag("Enemy"))) 
		{
			Destroy (this.gameObject); 
		}
	}


	void Fall()
	{
		rb2d.isKinematic = false;
	}



}