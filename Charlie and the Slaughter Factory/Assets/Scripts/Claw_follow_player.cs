using UnityEngine;
using System.Collections;

/**
 * This script is the claw following charlie as he runs across the game
 * 
 * Charlie and the Slaughter Factory : Teven Studios
 * */

public class Claw_follow_player : MonoBehaviour {

    public Transform player;
    public float speed = 4.0f;

    private Vector3 newPosition;

    private float yvalue;
    private float randomVar;
    private bool goDown;
    private bool hasPlayer = false;
    Quaternion rotation;

    void Start()
    {
        //finds the y value of the gameobject to use for the claw's position
        GameObject Claws = GameObject.FindGameObjectWithTag("Claw");
        yvalue = Claws.transform.position.y;
        randomVar = Random.Range(1f, 5f);
    }
	
	void Update () {
        // new position that the claw will move to

        if (!goDown) {
                if (transform.position.y >= yvalue)
                {
                    newPosition = transform.position - (transform.right * speed * Time.deltaTime);
                    newPosition.y = yvalue;
                }
                else
                {
                    newPosition.y = transform.position.y + (speed * Time.deltaTime);
                }
        } else {
            newPosition.y -= speed * Time.deltaTime;
        }

        if (Time.time > randomVar)
        {
            if (!goDown)
            {
                goDown = (Random.Range(0, 2) == 0);
            }
            randomVar += Random.Range(5f, 10f);
        }

        rotation = Quaternion.LookRotation(player.transform.position - transform.position, transform.TransformDirection(Vector3.up));
        transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);

        transform.position = newPosition; // set claw position as new value

        if (hasPlayer)
        {
            newPosition.y-= 2;
            player.position = newPosition;
            if (transform.position.y == yvalue)
            {
                hasPlayer = false;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            hasPlayer = true;
        }
        goDown = false;
    }
}
