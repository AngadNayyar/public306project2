using UnityEngine;
using System.Collections;
/**
 * This script is the script used to add damage to charlie on a collision
 * */

public class damage : MonoBehaviour
{
    public int attackDamage = 100;  //Damage taken due to hit
    GameObject player;  // Reference to Charlie
    PlayerHealth playerHealth;  // Reference to the Charlie's health.

    void Awake()
    {
        //instantiate player and player health
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
    }

	// Take health for objects that have a trigger - takes in a collider object 
 	void OnTriggerEnter2D(Collider2D collider) {
		if (collider.gameObject == player) { 				// check if collided against player
			playerHealth.TakeDamage(attackDamage); 			// take health from Charlie
        }
    }

	// Take health for objects without trigger - takes in a collision object
	void OnCollisionEnter2D(Collision2D collision) {
		if (collision.gameObject.CompareTag("Player")) {  		// check if collided against player
			playerHealth.TakeDamage(attackDamage);  			// take health from Charlie
		}
	}
		
}
