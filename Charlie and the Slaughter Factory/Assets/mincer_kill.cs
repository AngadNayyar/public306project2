using UnityEngine;
using System.Collections;

public class mincer_kill : MonoBehaviour
{
    public int attackDamage = 100;  //Damage taken due to hit
    GameObject player;  // Reference to Charlie
    PlayerHealth playerHealth;  // Reference to the Charlie's health.

    // Use this for initialization
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject == player)
        {
            playerHealth.TakeDamage(attackDamage);
        }
    }
}
