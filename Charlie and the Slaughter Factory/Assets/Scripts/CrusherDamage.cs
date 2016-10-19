using UnityEngine;
using System.Collections;

/*
 * This Script controls the damage of the crusher 
 *
 * Charlie and the Slaughter factory - Teven Studios
 */

public class CrusherDamage : MonoBehaviour {
    private int attackDamage = 100;  //Damage taken due to hit

    PlayerHealth playerHealth;  // Reference to the Charlie's health.
    PlayerScript playerScript; //Reference to Charlie's movement controls
    GameObject player;  // Reference to Charlie

    void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();

    }

    void Update() {
    }

	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.CompareTag("Player")) {
            playerHealth.TakeDamage(attackDamage);
        }
    }
}