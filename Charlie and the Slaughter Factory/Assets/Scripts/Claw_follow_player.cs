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
    public Vector3 position;

    // private instantiations
    private Vector3 newPosition;
    private float yvalue;
    private float randomVar;
    private bool goDown;
    private bool hasPlayer = false;
    private Quaternion rotation;

    void Start()
    {
        //finds the y value of the gameobject to use for the claw's position
        GameObject Claws = GameObject.FindGameObjectWithTag("Claw");
        yvalue = Claws.transform.position.y;
        randomVar = Random.Range(1f, 5f);

        // This is so the claw faces down when it goes down/ up
        position = new Vector3();
        position.y = transform.position.y - 5;

        // initialises first new position values
        newPosition = transform.position - (transform.right * speed * Time.deltaTime);
        newPosition.y = yvalue;
    }

	void Update () {
        //checks if claw is going down
        if (!goDown) {
                if (transform.position.y >= yvalue) // checks it goes to max the yvalue
                {
                    newPosition -= (transform.right * speed * Time.deltaTime); //decrease y position
                    newPosition.y = yvalue; // makes max yvalue
                    rotation = Quaternion.LookRotation(player.transform.position - transform.position, transform.TransformDirection(Vector3.up)); // looks at the player
                }
                else // makes go up
                {
                    newPosition.y += (speed * Time.deltaTime); // increase y position
                position.x = transform.position.x;
                rotation = Quaternion.LookRotation(position - transform.position, transform.TransformDirection(Vector3.up)); // looks directly down
                }
        } else { // makes go down
            newPosition.y -= speed * Time.deltaTime; //decrease y position
            position.x = transform.position.x;
            rotation = Quaternion.LookRotation(position - transform.position, transform.TransformDirection(Vector3.up)); //looks directly down
        }
        // set's the claw's rotation, where it should look
        transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);

        //RNG
        if (Time.time > randomVar)
        {
            if (!goDown) //if it isn't going down
            {
                goDown = (Random.Range(0, 2) == 0); // 50% chance of true
            }
            randomVar += Random.Range(2f, 6f); // seconds wait is between 2 and 6
        }

        transform.position = newPosition; // set claw position as new value

        if (hasPlayer) // checks if the claw has Charlie
        {
            newPosition.y-= 2; // distance 2 away from the claw
            player.position = newPosition; // sets this position as the chicken's position

            if (transform.position.y == yvalue) // checks if gets back to the top
            {
                hasPlayer = false; // sets to false so Chicken drops back down
            }
        }
    }

    //checks if it collides with anything on it's way down
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player") // sets the boolean as true for when it hits a player
        {
            hasPlayer = true;
        }
        goDown = false; // sets goDown boolean to false, so can goes back up
    }
}
