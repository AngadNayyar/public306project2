using UnityEngine;
using System.Collections;

public class CrusherMotion : MonoBehaviour {

	PlayerHealth playerHealth;  // Reference to the Charlie's health.
	PlayerScript playerScript; //Reference to Charlie's movement controls
	GameObject player;  // Reference to Charlie
	Rigidbody2D rigidBody;

	Rigidbody2D rb2d; 

	/*public Transform ceiling;
	public Transform floor;
	public bool collidingTop;
	public bool collidingGround; 
	public LayerMask detect; */ 
	//private bool comingDown = true; 

	private float velocity = 2f;
	private bool swap = false; 


	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
		playerHealth = player.GetComponent<PlayerHealth>();
		rigidBody = player.GetComponent<Rigidbody2D>();
		rb2d = GetComponent<Rigidbody2D> (); 
	}
	
	// Update is called once per frame
	void Update () {

		//colliding = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
		//collidingTop = Physics2D.Linecast(transform.position, floor.position, LayerMask.NameToLayer("Ground"));// detects if colliding against a wall
		//collidingGround = Physics2D.Linecast(ceiling.position, ceiling.position, LayerMask.NameToLayer("Ground"));// detects if colliding against a wall

		//Debug.Log (velocity); 
		rb2d.velocity = new Vector2(rb2d.velocity.x, velocity);

		/*
		if (swap) {
			//Debug.Log (rb2d.velocity.y); 
			//rb2d.velocity.y = rb2d.velocity.x + 1.0f;  
			velocity *= 1; 
		} else {
			//rb2d.AddForce (new Vector2 (0f, 100f)); 
		}
		//if (collidingTop) {
			//rb2d.AddForce(new Vector2(0f, 300f));
			//Debug.Log ("here!"); 
		//} */ 
	}


	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.CompareTag("Player")){
			
		} else if (other.gameObject.CompareTag("ground")) {

			swap = !swap;
			velocity *= -1; 
			Vector3 theScale = transform.localScale;
			theScale.x *= -1;
			transform.localScale = theScale;
		}
	}
}

