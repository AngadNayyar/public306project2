using UnityEngine;
using System.Collections;


/*
 * This script controls conveyor belt mechanics. 
 * When charlie touches/ stays-on the conveyor, his speed increases.  
 * 
 * To use this script, attach it to the conveyor belt platform object, which will need a collision box.  
 *  
 * Charlie and the Slaughter factory - Teven Studios
 */

public class Conveyor : MonoBehaviour
{

    // set the speed for the conveyor
    public int conveyorSpeed = 5;
    public bool movementRight = true;
    private bool conveyor;

    private GameObject player;  // Reference to Charlie

    void Start()
    {
        // Get the player rigid body
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (conveyor && !movementRight) // checks if colliding & moving left
        {
            player.transform.position = player.transform.position - (transform.right * conveyorSpeed * Time.deltaTime);
        }
        else if (conveyor && movementRight) // checks if colliding & moving right
        {
            player.transform.position = player.transform.position + (transform.right * conveyorSpeed * Time.deltaTime);
        }
    }

    // While charlie is on the conveyor add a speed to the right 
    void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            conveyor = true; //sets boolean to true if the floor is on it/ colliding with it
        }

    }

    //When Charlie hops off, stop accelerating
    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            conveyor = false; //sets boolean to false if the player leaves the conveyer belt

        }
    }
}
