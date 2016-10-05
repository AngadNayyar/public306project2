using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour
{

    [HideInInspector]
    public bool facingRight = true;

    private Rigidbody2D rb2d;
    private Animator anim;

    public float rightLimit = 1.0f;
    public float leftLimit = -4.0f;
    public float speed = 1.0f;
    private int direction = 1;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        Vector3 movement;
        if (transform.position.x > rightLimit)
        {
            direction = -1;         
            movement = Vector3.right * speed * Time.deltaTime;
            transform.Translate(movement);
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
        else if (transform.position.x < leftLimit)
        {
           direction = 1;
           movement = Vector3.right * speed * Time.deltaTime;
           transform.Translate(movement);
           transform.localRotation = Quaternion.Euler(0, 0, 0); // flips it
        }
        else {
            movement = Vector3.right * speed * Time.deltaTime;
            transform.Translate(movement);
        }
        
    }
}
