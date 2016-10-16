using UnityEngine;
using System.Collections;

/*
 * This script controls the cog 
 *
 * To use this script, attach it to the cog object.
 * You will also need to attach a RigidBody2D as well as attaching a polygon collider. 
 * The rigidbody2d will need to be Kinematic for the no gravity to work.  
 * Also note that if using a png as the cog, when adding a polygon collider it will automatically fit to the shape of the cog (yay). 
 *
 * currently the cog should be able to be placed anywhere due to the gravity of the object being disabled. 
 * Charlie and the Slaughter factory - Teven Studios
 */

public class Cog : MonoBehaviour {

	Rigidbody2D rb2d; 
	// Set the speed of the cog spin a larger negative number will cause a faster spin clockwise
	// For the cog to rotate anticlockwise 
	private float spinSpeed = -50.0f;


	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {

		// turn off the gravity so the cog can float 
		rb2d.gravityScale = 0f; 

		// Rotate the cog wheel about its center 
		transform.Rotate(Vector3.forward, spinSpeed * Time.deltaTime);
	}
}
