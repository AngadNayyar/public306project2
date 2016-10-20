using UnityEngine;
using System.Collections;

/**
 * This script is the claw following charlie as he runs across the game
 * NOTE: The claw MUST start to the right of Charlie
 * 
 * Charlie and the Slaughter Factory : Teven Studios
 * */

public class Claw_follow_player : MonoBehaviour {

    //public instantaitions - so can change
    public Transform player;
    public float speed = 4.0f;

    // private instantiations
    private Vector3 position;
    private Vector3 newPosition;
    private float yvalue;
    private float xvalue;
    private float randomVar;
    private bool goDown;
    private bool hasPlayer = false;
    private Quaternion rotation;

    void Start()
    {
        //finds the y value of the gameobject to use for the claw's position
        GameObject Claws = GameObject.FindGameObjectWithTag("Claw");
        yvalue = Claws.transform.position.y;
        xvalue = Claws.transform.position.x;
        randomVar = Random.Range(1f, 5f);

        // This is so the claw faces down when it goes down/ up
        position = new Vector3();
        position.y = transform.position.y - 5;
    }

	void Update () {

        if (player.transform.position.y > yvalue || player.transform.position.x > xvalue)
        {
            return;
        }

        //checks if claw is going down
        if (!goDown) {
                if (transform.position.y >= yvalue) // checks it goes to max the yvalue
                {
                    newPosition = transform.position - (transform.right * speed * Time.deltaTime); //decrease y position
                    newPosition.y = yvalue; // makes max yvalue
                    rotation = Quaternion.LookRotation(player.transform.position - transform.position, transform.TransformDirection(Vector3.up)); // looks at the player
                }
                else // makes go up
                {
                    newPosition = transform.position + (transform.right * speed * Time.deltaTime); // increase y position
                    position.x = transform.position.x;
                    rotation = Quaternion.LookRotation(position - transform.position, transform.TransformDirection(Vector3.up)); // looks directly down
                }
        } else { // makes go down
            newPosition = transform.position - (transform.right * speed * Time.deltaTime); //decrease y position
            position.x = transform.position.x;
            rotation = Quaternion.LookRotation(position - transform.position, transform.TransformDirection(Vector3.up)); //looks directly down
        }
        // set's the claw's rotation, where it should look
        transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);

        //RNG
        if (Time.time > randomVar)
        {
            if (transform.position.y == yvalue) //if it isn't going down (at the top value)
            {
                goDown = (Random.Range(0, 2) == 0); // 50% chance of true
            }
            randomVar += Random.Range(2f, 6f); // seconds wait is between 2 and 6
        }

        

        if (hasPlayer) // checks if the claw has Charlie
        {
            if (transform.position.y == yvalue) // checks if gets back to the top
            {
                //newPosition = transform.position - (transform.right * speed * Time.deltaTime);
                newPosition.x = transform.position.x + (5 * Time.deltaTime);
                newPosition.y = yvalue;

                if (newPosition.x >= xvalue)
                {
                    newPosition.x = xvalue;
                    transform.position = newPosition;
                    hasPlayer = false; // sets to false so Chicken drops back down
                }
                else
                {
                    // distance 2 away from the claw
                    transform.position = newPosition;

                    newPosition.y -= 2;
                    player.position = newPosition;
                }
            } else
            {
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
            return;
        }

        if (coll.gameObject.tag == "Player") // sets the boolean as true for when it hits a player
        {
            hasPlayer = true;
        }
        goDown = false; // sets goDown boolean to false, so can goes back up
    }
}
