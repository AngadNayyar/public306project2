using UnityEngine;
using System.Collections;

/*
 * This Script controls the mechanics of the character - Charlie the chicken
 * It controls his walking/running, jumping and sliding motions.
 *
 * Charlie and the Slaughter factory - Teven Studios
 */
public class PlayerScript : MonoBehaviour
{

    [HideInInspector]
    public bool facingRight = true;
    [HideInInspector]
    public bool jump = false;
    [HideInInspector]
    public bool canDoubleJump = false;
    private bool doubleJump = false;

    private float maxSpeed = 5f;
    private float speed = 365f;
    private float walkingMaxSpeed = 5f;
    private float maxSlideSpeed = 1f;
    private float jumpForce = 600f;
    public Transform groundCheck;
    public bool slide = false;
    public bool grounded = false;

    private Rigidbody2D rb2d;
    private Animator anim;
    private BoxCollider2D bc;
    private CircleCollider2D cc;
    private int coinCount;

    // Use this for initialization
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        //bc = gameObject.GetComponent<BoxCollider2D> ();
        cc = gameObject.GetComponent<CircleCollider2D>();
        coinCount = 0;
        PlayerPrefs.SetInt("LevelCoins", coinCount);
    }

    // Update is called once per frame
    void Update()
    {

        // Check if the character is on the gorund.
        grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

        // If the space bar is pressed and the character is gounded and not sliding make him jump
        if (Input.GetKeyDown(KeyCode.Space) && grounded && !slide)
        {
            jump = true;
        }

        if (Input.GetKeyDown(KeyCode.Space) && !grounded && canDoubleJump)
        {
            doubleJump = true;
        }

        // If the down arrow key is pressed and he is not jumping, make the character slide, and set the box collider to a smaller height.
        if ((Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S)) && grounded)
        {
            canDoubleJump = false;
            slide = true;
            //bc.size = new Vector2 (5.95f, 1.7f);
            cc.radius = 2.0f;
            anim.SetBool("Slide", true);
        }

        // If the down arrow key is released, make the character stop sliding, and set the box collider to a original height.
        if (Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.S))
        {
            slide = false;
            anim.SetBool("Slide", false);
            //bc.size = new Vector2 (5.95f, 3.16f);
            cc.radius = 3.0f;
        }


    }

    // Update function
    void FixedUpdate()
    {
        // Gets the horizontal direction of the movement from the user
        float h = Input.GetAxis("Horizontal");
        anim.SetFloat("Speed", Mathf.Abs(h));

        // If the character is facing right and moving left, or facing left and moving right, flip the character
        if (h > 0 && !facingRight)
            Flip();
        else if (h < 0 && facingRight)
            Flip();

        // If the space bar is pressed and the character is gounded it will jump once
        if (jump)
        {
            anim.SetTrigger("Jump");
            rb2d.AddForce(new Vector2(0f, jumpForce));
            jump = false;
            canDoubleJump = true;
        }

        // If the space bar is pressed while the character is jumping - it will double jump
        if (Input.GetKey(KeyCode.Space) && doubleJump)
        {
            canDoubleJump = false;
            doubleJump = false;
            anim.SetTrigger("Jump");
            rb2d.Sleep();
            rb2d.AddForce(new Vector2(0f, jumpForce));
        }

        // Slide functionality - set a slower max speed value
        if (slide)
        {
            maxSpeed = maxSlideSpeed;
        }

        // Makes the character move left and right
        if (h * rb2d.velocity.x < maxSpeed)
            rb2d.AddForce(Vector2.right * h * speed);

        // Stops velocity going above max speed
        if (Mathf.Abs(rb2d.velocity.x) > maxSpeed)
            rb2d.velocity = new Vector2(Mathf.Sign(rb2d.velocity.x) * maxSpeed, rb2d.velocity.y);

        // Reset the max speed to be the original value for the walk/run
        maxSpeed = walkingMaxSpeed;

    }

    // Flip the sprite to face the other direction
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    //checks if stays on a platform object
    void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.tag == "Platform")
        {
           transform.parent = col.transform; // move at the rate of the platform
        }
    }
    //check if gets off the platform object
    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "Platform")
        {
            transform.parent = null; // set movement to null again
        }
    }
    /* //method to increase player's number of coins when they collide with one
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            //other.gameObject.SetActive(false);
            coinCount = coinCount + 1;
            Debug.Log(coinCount);
            PlayerPrefs.SetInt("LevelCoins", coinCount);
        }

    } */
}
