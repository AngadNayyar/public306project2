using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour
{

    // instantiates the boundaries's and speed of the object
    public float rightLimit = 1.0f;
    public float leftLimit = -4.0f;
    public float speed = 1.0f;
    public GameObject player;

    // Use this for initialization
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){}

    void FixedUpdate()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        float player_pos = player.transform.position.x;
        if (player_pos < rightLimit && player_pos > leftLimit)
        {
            if (true) {
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
        }
        else if (transform.position.x < leftLimit) // checks if the dog is past the left edge
        {
           transform.localRotation = Quaternion.Euler(0, 0, 0); // flips the dog
        }
    }
}
