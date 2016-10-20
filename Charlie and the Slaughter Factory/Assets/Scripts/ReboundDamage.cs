using UnityEngine;
using System.Collections;


public class ReboundDamage : MonoBehaviour {

    PlayerScript playerScript; //Reference to Charlie's movement controls
    GameObject player;  // Reference to Charlie
    Rigidbody2D rigidBody;

    void Awake() {
        player = GameObject.FindGameObjectWithTag("Player");
        rigidBody = player.GetComponent<Rigidbody2D>();
    }

    void Update() {
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject == player){
            rigidBody.Sleep();
            if (other.transform.position.x < transform.position.x){
                rigidBody.AddForce(new Vector2(-300f, 600f));
            } else if (other.transform.position.x > transform.position.x){
                rigidBody.AddForce(new Vector2(300f, 600f));
            }
        }
    }
}