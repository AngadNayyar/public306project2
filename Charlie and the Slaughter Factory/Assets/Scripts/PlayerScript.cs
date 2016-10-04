using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	[HideInInspector] public bool facingRight = true;
	[HideInInspector] public bool jump = false;
	[HideInInspector] public bool canDoubleJump = false;

	public float maxSpeed = 5f;
	public float speed = 365f;
<<<<<<< HEAD
	public float jumpForce = 550f;

=======
	public float jumpForce = 500f;
>>>>>>> refs/remotes/origin/master
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

		// Check if the character is on the gorund. 
		grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

		// If the space bar is pressed and the character is gounded make him jump 
		if (Input.GetKeyDown(KeyCode.Space) && grounded) {
			jump = true; 
		}
	}

	void FixedUpdate() {

		float h = Input.GetAxis("Horizontal");
		anim.SetFloat("Speed", Mathf.Abs(h)); 

		// Makes the character move left and right
		if (h * rb2d.velocity.x < maxSpeed)
			rb2d.AddForce(Vector2.right * h * speed); 

		// Stops velocity going above max speed 
		if (Mathf.Abs (rb2d.velocity.x) > maxSpeed)
			rb2d.velocity = new Vector2(Mathf.Sign (rb2d.velocity.x) * maxSpeed, rb2d.velocity.y);

		// If the character is facing right and moving left, or facing left and moving right, flip the character
		if (h > 0 && !facingRight)
			Flip();
		else if (h < 0 && facingRight)
			Flip();

		// If the space bar is pressed and the character is gounded it will jump once 
		if (jump) {
			anim.SetTrigger("Jump");
			rb2d.AddForce(new Vector2(0f, jumpForce));
			jump = false;
			canDoubleJump = true; 
		}

		// If the space bar is pressed while the character is jumping - it will double jump 
		if (Input.GetKeyDown(KeyCode.Space) && canDoubleJump) {
			canDoubleJump = false; 
			//anim.SetTrigger("Jump");
			//rigidbody2D.velocity.y = 0;
			rb2d.AddForce(new Vector2(0f, jumpForce));
		}

	}

	// Flip the sprite to face the other direction 
	void Flip()
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
