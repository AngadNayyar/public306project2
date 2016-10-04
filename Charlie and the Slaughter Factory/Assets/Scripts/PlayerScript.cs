using UnityEngine;
using System.Collections;

/*
 * This Script controls the mechanics of the character - Charlie the chicken 
 * It controls his walking/running, jumping and sliding motions.  
 * 
 * Charlie and the Slaughter factory - Teven Studios 
 */ 
public class PlayerScript : MonoBehaviour {

	[HideInInspector] public bool facingRight = true;
	[HideInInspector] public bool jump = false;
	[HideInInspector] public bool canDoubleJump = false;

	private float maxSpeed = 5f;
	private float speed = 365f;
	private float walkingMaxSpeed = 5f; 
	private float maxSlideSpeed = 1f; 
	private float jumpForce = 500f;
	public Transform groundCheck; 
	public bool slide = false; 
	public bool grounded = false;

	private Rigidbody2D rb2d;
	private Animator anim;
	private BoxCollider2D bc; 


	// Use this for initialization
	void Start () {
		anim = gameObject.GetComponent<Animator>();
		rb2d = gameObject.GetComponent<Rigidbody2D>();
		bc = gameObject.GetComponent<BoxCollider2D> (); 
	}

	// Update is called once per frame
	void Update () {

		// Check if the character is on the gorund. 
		grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

		// If the space bar is pressed and the character is gounded make him jump 
		if (Input.GetKeyDown(KeyCode.Space) && grounded) {
			jump = true; 
		}

		// If the down arrow key is pressed, make the character slide, and set the box collider to a smaller height. 
		if (Input.GetKeyDown (KeyCode.DownArrow)) {
			slide = true; 
			bc.size = new Vector2 (51, 20); 
		}
	
		// If the down arrow key is released, make the character stop sliding, and set the box collider to a original height. 
		if (Input.GetKeyUp (KeyCode.DownArrow)) {
			slide = false;
			bc.size = new Vector2 (51, 47);
		}


	}

	// Update function 
	void FixedUpdate() {

		// Gets the horizontal direction of the movement from the user 
		float h = Input.GetAxis("Horizontal");
		anim.SetFloat("Speed", Mathf.Abs(h)); 
	
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
			
		// Slide functionality - set a slower max speed value 
		if (slide) {
			maxSpeed = maxSlideSpeed;  
		} 
			
		// Makes the character move left and right
		if (h * rb2d.velocity.x < maxSpeed)
			rb2d.AddForce(Vector2.right * h * speed); 

		// Stops velocity going above max speed 
		if (Mathf.Abs (rb2d.velocity.x) > maxSpeed)
			rb2d.velocity = new Vector2(Mathf.Sign (rb2d.velocity.x) * maxSpeed, rb2d.velocity.y);  

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
		

}
