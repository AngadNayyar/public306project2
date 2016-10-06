using UnityEngine;
using System.Collections;


public class DogDamage : MonoBehaviour {
    private int attackDamage = 25;  //Damage taken due to hit

    PlayerHealth playerHealth;  // Reference to the Charlie's health.
    PlayerScript playerScript; //Reference to Charlie's movement controls
    GameObject player;  // Reference to Charlie
    Rigidbody2D rigidBody;

    void Awake() {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        playerScript = player.GetComponent<PlayerScript>();
        rigidBody = player.GetComponent<Rigidbody2D>();
        
    }

    void Update() {
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject == player){
            playerHealth.TakeDamage(attackDamage);

            rigidBody.Sleep();
            if (other.transform.position.x < transform.position.x){
                rigidBody.AddForce(new Vector2(-300f, 600f));
            } else if (other.transform.position.x > transform.position.x){
                rigidBody.AddForce(new Vector2(300f, 600f));
            }
        }
    }
}