using UnityEngine;
using System.Collections;

/**
 * This script is the claw following charlie as he runs across the game
 * 
 * Charlie and the Slaughter Factory : Teven Studios
 * */

public class Claw_follow_player : MonoBehaviour {

    //public instantiations - so can change
    public Transform player;
    public float speed = 4.0f;

    // private instantiations
    private Vector3 position; // This is the position the claw should face when it picks charlie up
    private Vector3 newPosition; // The new position of the claw/ player
    private float yvalue; // y value of claw max
    private float xvalue; // x value to compare to where charlie is
    private float randomVar = 0; // RNG variable used
    private bool goDown = false;
    private bool hasPlayer = false;
    private Quaternion rotation;

    void Start()
    {
        //finds the y value of the gameobject to use for the claw's position
        GameObject Claws = GameObject.FindGameObjectWithTag("Claw");
        yvalue = Claws.transform.position.y;
        xvalue = Claws.transform.position.x;
        randomVar = Random.Range(2f, 4f); // intialise a random number

        // This is so the claw faces down when it goes down/ up
        position = new Vector3();
        position.y = transform.position.y - 5;
    }

	void Update () {

        // return if Charlie isn't left and below the initial position of the Claw object
        if (player.transform.position.y > yvalue || player.transform.position.x > xvalue)
        {
            return;
        }

        //checks if claw is going down
        if (!goDown) {
                if (transform.position.y >= yvalue) // checks the claw goes to max the yvalue
                {
                    newPosition = transform.position - (transform.right * speed * Time.deltaTime); //decrease y position
                    newPosition.y = yvalue; // makes max yvalue
                    rotation = Quaternion.LookRotation(player.transform.position - transform.position, transform.TransformDirection(Vector3.up)); // looks at the player
                }
                else // makes claw go up
                {
                    newPosition = transform.position + (transform.right * speed * Time.deltaTime); // increase y position
                    position.x = transform.position.x; // set x value as constant when going up/ down
                    rotation = Quaternion.LookRotation(position - transform.position, transform.TransformDirection(Vector3.up)); // looks directly down at floor
                }
        } else { // makes go down
            newPosition = transform.position - (transform.right * speed * Time.deltaTime); //decrease y position
            position.x = transform.position.x;
            rotation = Quaternion.LookRotation(position - transform.position, transform.TransformDirection(Vector3.up)); //looks directly down
        }
        // set's the claw's rotation, where it should look
        transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);

        //RNG
        // Checks randomly every 2 to 6 seconds whether the claw is currently going down, and if it isn't it has a 50% chance to go down
        if (Time.time > randomVar)
        {
            if (transform.position.y == yvalue && !hasPlayer) //if it isn't going down (at the top value) && doesn't have Charlie
            {
                goDown = (Random.Range(0, 2) == 0); // 50% chance of true
            }
            randomVar += Random.Range(2f, 6f); // seconds wait is between 2 and 6
        }

        if (hasPlayer) // checks if the claw has Charlie
        {
            if (transform.position.y == yvalue) // checks if gets back to the top
            {
                newPosition.x = transform.position.x + (5 * Time.deltaTime); // moves charlie back to xvalue point (left) by a speed of 5
                newPosition.y = yvalue; // makes position max y value

                if (newPosition.x >= xvalue)
                {
                    newPosition.x = xvalue;
                    transform.position = newPosition;
                    hasPlayer = false; // sets to false so Chicken drops back down
                }
                else
                {
                    // distance of Charlie 2 below the claw
                    transform.position = newPosition;
                    newPosition.y -= 2;
                    player.position = newPosition;
                }
            } else
            {
                // distance of Charlie 2 below the claw
                transform.position = newPosition; // set claw position as new value
                newPosition.y -= 2;
                player.position = newPosition; // sets this position as the chicken's position
            }
        } else
        {
            transform.position = newPosition; // set claw position as new value
        }
    }

    //checks if it collides with anything on it's way down
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "ChickenCollectable")
        {
            return; // don't react to chicken collectables
        }

        if (coll.gameObject.tag == "Player") // sets the boolean as true for when it hits a player
        {
            hasPlayer = true;
        }
        goDown = false; // sets goDown boolean to false, so can goes back up
    }
}
