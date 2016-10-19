using UnityEngine;
using System.Collections;

public class Mincer : MonoBehaviour
{
    public float speed = 3; // mincer doors speed
    public float dir = 1; // 1 = right, -1 = left

    private int attackDamage = 100;  //Damage taken due to hit
    PlayerHealth playerHealth;  // Reference to the Charlie's health.
    PlayerScript playerScript; //Reference to Charlie's movement controls
    GameObject player;  // Reference to Charlie
    Rigidbody2D rigidBody;

    void Awake()
    {
        //used later for player damage
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        rigidBody = player.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //move the object at a rate of 1*speed unit/s along the x-axis
        transform.Translate(new Vector3(1, 0, 0) * Time.deltaTime * dir * speed);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        //check if mincer hits another mincer
        if (col.gameObject.tag == "Mincer")
        {
            //reverse the direction of the mincer door
            dir *= -1;
        }
        if (col.gameObject == player)
        {
            print("Hit player");

            EdgeCollider2D edge = transform.GetComponent<EdgeCollider2D>();
            if (this.gameObject == edge)
            {
                print("it's the edge");
                playerHealth.TakeDamage(attackDamage);
            }
            
        }
    }
}