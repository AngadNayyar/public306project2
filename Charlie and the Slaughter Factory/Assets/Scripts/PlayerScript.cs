using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

    [HideInInspector]
    public bool facingRight = true;
    [HideInInspector]
    public bool jump = true;

    public float maxSpeed = 3f;
    public float speed = 20f;
    public float jumpPower = 150f;

    public bool grounded;


    private Rigidbody2D rb2d;
    private Animator anim;


	// Use this for initialization
	void Start () {
        anim = gameObject.GetComponent<Animator>();
        rb2d = gameObject.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown("space"))
            rb2d.AddForce(new Vector2(0, 6), ForceMode2D.Impulse);

    }

    void FixedUpdate() {

        float h = Input.GetAxis("Horizontal");

        rb2d.AddForce(Vector2.right * h * speed); // Can move left and right

        if (rb2d.velocity.x > maxSpeed)
            rb2d.velocity = new Vector2(maxSpeed, rb2d.velocity.y); // Stops velocity going above max speed
        if (rb2d.velocity.x < -maxSpeed)
            rb2d.velocity = new Vector2(-maxSpeed, rb2d.velocity.y); // Stops velocity going above max speed

        if (h > 0 && !facingRight)
            Flip();
        else if (h < 0 && facingRight)
            Flip();
    }


    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
