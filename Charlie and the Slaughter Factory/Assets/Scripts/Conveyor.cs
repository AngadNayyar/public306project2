using UnityEngine;
using System.Collections;


/*
 * This script controls conveyor belt mechanics. 
 * When charlie touches the conveyor, his speed increases.  
 * 
 * To use this script, attach it to the conveyor belt platform object, which will need a collision box.  
 *  
 * Charlie and the Slaughter factory - Teven Studios
 */

public class Conveyor : MonoBehaviour
{

    // set the speed for the conveyor
    public int conveyorSpeed = 5;
    GameObject player;  // Reference to Charlie
    Rigidbody2D playerBody;
    public bool movementRight = true;
    private int maxOppositeSpeed = 3;
    private bool conveyor;

    // Use this for initialization
    void Start()
    {
        // Get the player rigid body
        player = GameObject.FindGameObjectWithTag("Player");
        playerBody = player.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (conveyor && !movementRight)
        {
            player.transform.position = player.transform.position - (transform.right * conveyorSpeed * Time.deltaTime);
        }
        else if (conveyor && movementRight)
        {
            player.transform.position = player.transform.position + (transform.right * conveyorSpeed * Time.deltaTime);
        }
    }

    // While charlie is on the conveyor add a speed to the right 
    void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            /*if (movementRight) {
				if (Mathf.Abs(playerBody.velocity.x) < maxOppositeSpeed) {
					playerBody.velocity = playerBody.velocity + Vector2.right * conveyorSpeed;
				} else {
					playerBody.velocity = Vector2.right * maxOppositeSpeed;
				} 

			}  else {
				if (Mathf.Abs(playerBody.velocity.x) < maxOppositeSpeed) {
					playerBody.velocity = playerBody.velocity + Vector2.left * conveyorSpeed;
				} else {
					playerBody.velocity = Vector2.left * maxOppositeSpeed;
				} 
			}  */
            conveyor = true;
        }

    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            conveyor = false;

        }
    }
}
