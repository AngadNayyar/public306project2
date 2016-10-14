using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour
{

    // instantiates the boundaries's and speed of the object
    private float rightLimit = 3.8f;
    private float leftLimit = -1.4f;
    private float speed = 1.0f;
    public float velocity = 1.0f;
    private bool facingRight = true;
    GameObject player;

    public Transform sightStart;
    public Transform sightEnd;

    public bool colliding;
    public LayerMask detectWhat;


    // Use this for initialization
    void Start(){}

    // Update is called once per frame
    void Update()
    {
        Rigidbody2D rgb = GetComponent<Rigidbody2D>(); //gets the dog's rigid body
        rgb.velocity = new Vector2(velocity, rgb.velocity.y); //sets the velocity

        colliding = Physics2D.Linecast(sightStart.position, sightEnd.position, detectWhat);// detects if colliding against a wall

        if (colliding) //checks if it's colliding against a wall
        { // spins the dog around if it's colliding against a wall
            transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
            velocity *= -1;
        }

        player = GameObject.FindGameObjectWithTag("Player"); // gets the player
        float player_pos = player.transform.position.x; // gets the player's position
        float player_dif_x = player_pos - transform.position.x;
        float player_dif_y = player.transform.position.y - transform.position.y;
        if (velocity > 0) //going right
        {
            if (player_dif_x < 4 && player_dif_x > 0 && player_dif_y < 0) // if facing the chicken
            {
                velocity = 5f;
            } else
            {
                velocity = 1f;
            }
        }
        else //going left
        {
            if (player_dif_x > -4 && player_dif_x < 0 && player_dif_y < 0) // if facing the chicken
            {
                velocity = -5f;
            } else
            {
                velocity = -1f;
            }
        }

       /* if (player_pos < rightLimit && player_pos > leftLimit && player.transform.position.y < -3)
        {
            if ((player_pos < transform.position.x && !facingRight) || (player_pos > transform.position.x && facingRight))
            {
                velocity = -5.0f;
            }
            else
            {
                velocity = -1.0f;
            }
        }
        */

    }
}
