using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour { // Moving Object

    public int playerDamage;
    private Animator anim;
    private Transform target;
    private bool skipMove;

    public float velocity = 1f;
    public Transform sightStart;
    public Transform sightEnd;

    public bool colliding;
    public LayerMask detectWhat;
    public bool facingRight = true;
    

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        //     target = GameObject.FindGameObjectsWithTag("Player").transform;
        //   base.Start();
    }

    public float rightLimit = 20f;
    public float leftLimit = -4.3f;
    public float speed = 1.0f;
    private int direction = 1;

    void Update()
    {
        
        if (transform.position.x > rightLimit)
        {
            // facingRight = true;
            print("right");
            print(transform.position.x);
            Flip();
        }
        else if (transform.position.x < leftLimit)
        {
            //facingRight = false;
            print("left");
            print(transform.position.x);
            print(leftLimit);
            Flip();
        }
      //  Vector3 movement = 
       // transform.Translate(movement);
    }

    // Update is called once per frame
    /* void Update() {
         GetComponent<Rigidbody2D>().velocity = new Vector2(velocity, GetComponent<Rigidbody2D>().velocity.y);

         colliding = Physics2D.Linecast(transform.position, transform.position, detectWhat);

         if (colliding)
         {
             Flip();
         }
     }*/

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
        colliding = false;
    }

    // void AttemptMove<T> (int xDir, int yDir)
}
