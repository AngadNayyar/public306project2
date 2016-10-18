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

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject == player) // check if collided against player
        {
            // take health from Charlie
            playerHealth.TakeDamage(attackDamage);
        }
    }
}
