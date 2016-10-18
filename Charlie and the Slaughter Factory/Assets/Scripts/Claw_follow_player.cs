using UnityEngine;
using System.Collections;

/**
 * This script is the claw following charlie as he runs across the game
 * 
 * 
 * */

public class Claw_follow_player : MonoBehaviour {

    public Transform player;
    public float speed = 4.0f;
    private Vector3 newPosition;
    private GameObject Claws;
    private float yvalue;
    private float variable;
    private bool goDown;
    private bool hasPlayer = false;

    void Start()
    {
        //finds the y value of the gameobject to use for the claw's position
        Claws = GameObject.FindGameObjectWithTag("Claw");
        yvalue = Claws.transform.position.y;
        variable = Random.Range(1f, 5f);
    }
	
	void Update () {
        // rotate the claw to be facing Charlie

        newPosition = transform.position - (transform.right * speed * Time.deltaTime);

        if (!goDown)
        {
                if (transform.position.y >= yvalue)
                {
                    newPosition.y = yvalue;
                }
                else
                {
                    newPosition.y = transform.position.y + (speed * Time.deltaTime);
                }
        } else {
            newPosition.y -= speed * Time.deltaTime;
        }

        if (hasPlayer)
        {
            player.position = newPosition;
            if (player.position.y == yvalue){
                hasPlayer = false;
            }
        }

        if (Time.time > variable)
        {
            if (!goDown)
            {
                goDown = (Random.Range(0, 2) == 0);
            }
            variable += Random.Range(5f, 10f);
        }

        if (!hasPlayer && !goDown)
        {
            Quaternion rotation = Quaternion.LookRotation(player.transform.position - transform.position, transform.TransformDirection(Vector3.up));
            transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);
        }

        transform.position = newPosition; // set claw position as new value
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
