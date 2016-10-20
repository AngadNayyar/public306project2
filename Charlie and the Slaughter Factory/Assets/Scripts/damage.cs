using UnityEngine;
using System.Collections;
/**
 * This script is used to add damage to charlie on a collision with the said object this script is attached to
 *  
 * Charlie and the Slaughter Factory : Teven Studios
 * */

public class damage : MonoBehaviour
{
    //initialise values
    public int attackDamage = 100;  //Damage taken due to hit: able to edit from inspector 
    private GameObject player;  // Reference to Charlie
    private PlayerHealth playerHealth;  // Reference to the Charlie's health.

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
