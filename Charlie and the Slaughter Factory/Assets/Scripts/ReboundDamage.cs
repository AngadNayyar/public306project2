using UnityEngine;
using System.Collections;

/**
 * This script causes the body to bounce back from the object that caused damage to it
 * 
 *  Charlie and the Slaughter factory - Teven Studios
 *  **/
public class ReboundDamage : MonoBehaviour {

    //instantiation of variables
    private GameObject player;  // Reference to Charlie
    private Rigidbody2D rigidBody;

    void Awake() { // gets player and it's rigid body
        player = GameObject.FindGameObjectWithTag("Player");
        rigidBody = player.GetComponent<Rigidbody2D>();
    }

    //checks for collisions
    void OnTriggerEnter2D(Collider2D other){

        if(other.gameObject == player){ // checks if the gameobject that the player collides against is the player

            rigidBody.Sleep(); // puts the body to sleep

            // checks if direction of charlie from the center of the object, and applies a bounce-back force to Charlie
            if (other.transform.position.x < transform.position.x){ 
                rigidBody.AddForce(new Vector2(-300f, 600f));
            } else if (other.transform.position.x > transform.position.x){
                rigidBody.AddForce(new Vector2(300f, 600f));
            }
        }
    }
}
