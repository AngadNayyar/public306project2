using UnityEngine;
using System.Collections;

/*
 * This script controls the falling objects
 * 
 * To use this script, attach it to the object. You will also need to create a RigidBody2D as well as attaching a collider 
 * 
 * Also the objects currently will need to be placed at the top of the screen ready to fall 
 *  
 * Charlie and the Slaughter factory - Teven Studios
 */ 

public class FallingObject : MonoBehaviour {

	public float spinSpeed = 250.0f;
	PlayerHealth playerHealth;  // Reference to the Charlie's health.
	GameObject player;  // Reference to Charlie
	Rigidbody2D playerBody;

	// Set the amount of damage to take off 
	private int fallDamage = 20; 

	// Set the distance for when the object should start falling when Charlie is within a certain distance 
	private int triggerDistance = 3; 

	//Set the gravity scale for the objects - a larger number is a faster fall 
	private float gravityScale = 0.1f; 

	private Rigidbody2D rb2d;

	void Awake() {
		player = GameObject.FindGameObjectWithTag("Player");
		playerHealth = player.GetComponent<PlayerHealth>();
		playerBody = player.GetComponent<Rigidbody2D>();

	}

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D>();
		rb2d.gravityScale = 0.0f; 
	}
		
	// Update is called once per frame
	void Update() {

		float player_pos = player.transform.position.x; 

		if (Mathf.Abs(player_pos - transform.position.x) < triggerDistance) {
			rb2d.gravityScale = gravityScale; 
		}

		transform.Rotate(Vector3.forward, spinSpeed * Time.deltaTime);
	}

	// When the object collides with player, take health and then destroy the object 
	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.CompareTag("Player")){
			playerHealth.TakeDamage(fallDamage);
		}
		Destroy (this.gameObject); 

	}
}
	