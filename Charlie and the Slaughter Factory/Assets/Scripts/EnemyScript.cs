using UnityEngine;
using System.Collections;
/**
 * This script is used by the Enemy dogs
 * Runs faster if the dog is facing charlie and he is within 4 units of charlie
 * If hits a "Wall", turns around
 * */
public class EnemyScript : MonoBehaviour
{
    // instantiates the boundaries's and speed of the object
    public float velocity;
    private float start_velocity;
    GameObject player;
    public Transform sightStart;
    public Transform sightEnd;
    public bool colliding;
    public LayerMask detectWhat;

    // Use this for initialization
    void Start(){
        start_velocity = velocity;
    }

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

        float player_dif_x = player_pos - transform.position.x; // gets charlie and the dogs difference in x values
        float player_dif_y = player.transform.position.y - transform.position.y;  // gets charlie and the dogs difference in y values

        if (velocity > 0) //going right
        {
            if (player_dif_x < 4 && player_dif_x > 0 && player_dif_y < 0) // if within 4 units of eachother and charlie is lower then the dog
            { //make dog run faster
                velocity = 2*start_velocity;
            } else
            { //make dog run normal
                velocity = start_velocity;
            }
        }
        else //going left
        {
            if (player_dif_x > -4 && player_dif_x < 0 && player_dif_y < 0) // if within 4 units of eachother and charlie is lower then the dog
            { // make dog run faster
                velocity = -2* start_velocity;
            } else
            { // make dog run normal
                velocity = -start_velocity;
            }
        }
    }
}
