using UnityEngine;
using System.Collections;


public class SawDamage : MonoBehaviour {
    public int attackDamage = 40;  //Damage taken due to hit

    PlayerHealth playerHealth;  // Reference to the Charlie's health.

    void Start() {
    }

    void Update() {
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.name == "Charlie"){
            playerHealth.TakeDamage(attackDamage);
        }
    }
}