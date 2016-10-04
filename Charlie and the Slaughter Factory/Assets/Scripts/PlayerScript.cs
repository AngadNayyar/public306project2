using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	[HideInInspector] public bool facingRight = true;
	[HideInInspector] public bool jump = false;

	public float maxSpeed = 5f;
	public float speed = 365f;
	public float jumpForce = 550f;

	public Transform groundCheck; 
	public bool grounded = false;

	private Rigidbody2D rb2d;
	private Animator anim;


	// Use this for initialization
	void Start () {
		anim = gameObject.GetComponent<Animator>();
		rb2d = gameObject.GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update () {

		grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

		if (Input.GetKeyDown(KeyCode.Space) && grounded) {
			jump = true; 
			//rb2d.AddForce (new Vector2 (0, 6), ForceMode2D.Impulse);
		}

	}

	void FixedUpdate() {

		float h = Input.GetAxis("Horizontal");

		anim.SetFloat("Speed", Mathf.Abs(h)); 

		// Can move left and right
		if (h * rb2d.velocity.x < maxSpeed)
			rb2d.AddForce(Vector2.right * h * speed); 

		/*
        if (rb2d.velocity.x > maxSpeed)
            rb2d.velocity = new Vector2(maxSpeed, rb2d.velocity.y); // Stops velocity going above max speed
        if (rb2d.velocity.x < -maxSpeed)
            rb2d.velocity = new Vector2(-maxSpeed, rb2d.velocity.y); // Stops velocity going above max speed
		*/ 

		// Stops velocity going above max speed
		if (Mathf.Abs (rb2d.velocity.x) > maxSpeed)
			rb2d.velocity = new Vector2(Mathf.Sign (rb2d.velocity.x) * maxSpeed, rb2d.velocity.y);

		if (h > 0 && !facingRight)
			Flip();
		else if (h < 0 && facingRight)
			Flip();

		if (jump)
		{
			anim.SetTrigger("Jump");
			rb2d.AddForce(new Vector2(0f, jumpForce));
			jump = false;
		}
	}


	void Flip()
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
