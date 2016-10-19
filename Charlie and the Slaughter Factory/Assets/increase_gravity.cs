using UnityEngine;
using System.Collections;

/**
 * This script makes sure that if Charlie enters the box collider, gravity increases so much that he can not make the jump
 * 
 * */
public class increase_gravity : MonoBehaviour {

    //instantiate the player
    GameObject player;
    Rigidbody2D rgb;

    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        rgb = player.GetComponent<Rigidbody2D>();
    }

    //increase player gravity if collides with the box
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject == player) // check if collided against player
        {
            rgb.AddForce(Vector3.down * 500f * rgb.mass); // increase gravity by 500f from 1
        }
    }
}
