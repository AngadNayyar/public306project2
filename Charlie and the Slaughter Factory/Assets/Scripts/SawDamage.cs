using UnityEngine;
using System.Collections;


public class SawDamage : MonoBehaviour {
    public int attackDamage = 40;  //Damage taken due to hit

    PlayerHealth playerHealth;  // Reference to the Charlie's health.
    GameObject player;  // Reference to Charlie

    void Awake() {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
    }

    void Update() {
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject == player){
            playerHealth.TakeDamage(attackDamage);
        }
    }
}