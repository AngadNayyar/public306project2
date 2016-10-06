using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour
{

    // instantiates the boundaries's and speed of the object
    private float rightLimit = 3.8f;
    private float leftLimit = -1.4f;
    private float speed = 1.0f;
    private bool facingRight = true;
    GameObject player;

    // Use this for initialization
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){}

    void FixedUpdate()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        float player_pos = player.transform.position.x;
        if (player_pos < rightLimit && player_pos > leftLimit && player.transform.position.y < -3)
        {
                if ((player_pos < transform.position.x && !facingRight) || (player_pos > transform.position.x && facingRight)) {
                    speed = 5.0f;
                }
                else
                {
                    speed = 1.0f;
                }
        }
        else
        {
            speed = 1.0f;
        }

        Vector3 movement = Vector3.right * speed * Time.deltaTime; // makes the speed/ movement of the dog
        transform.Translate(movement); // applies the movement to the dog

        if (transform.position.x > rightLimit) // checks if the dog is past the right edge
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0); // flips the dog
            facingRight = false;
        }
        else if (transform.position.x < leftLimit) // checks if the dog is past the left edge
        {
           transform.localRotation = Quaternion.Euler(0, 0, 0); // flips the dog
            facingRight = true;
        }
    }
}
