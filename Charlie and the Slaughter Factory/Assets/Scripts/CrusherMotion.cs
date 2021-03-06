﻿using UnityEngine;
using System.Collections;

/*
 * This Script controls the mechanics of the crusher.
 * To use a crusher use a crusher prefab 
 * 
 * To make the crusher go faster change the speed in the inspector 
 * The layer above and below must be set with the ground tag and ground layer. 
 *
 * Charlie and the Slaughter factory - Teven Studios
 */

public class CrusherMotion : MonoBehaviour {

	Rigidbody2D rb2d; //reference to the crusher 
	public float velocity = 2f; // speed of the crusher motion
	private bool swap = false; 
	private AudioSource source;


	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D> (); 
		source = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		// update the velocity of crusher 
		rb2d.velocity = new Vector2(rb2d.velocity.x, velocity);

	}

	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.CompareTag("ground")) {
			// swap the direction of the crusher motion when hit ground or ceiling
			source.Play(); //play the audio clip when the crusher hits the ground
			swap = !swap;
			velocity *= -1; 
			Vector3 theScale = transform.localScale;
			theScale.x *= -1;
			transform.localScale = theScale;
		}
	}
}

