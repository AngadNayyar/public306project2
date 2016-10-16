using UnityEngine;
using System.Collections;

public class Conveyor : MonoBehaviour {

	// set the speed for the conveyor
	private int conveyorSpeed = 10; 
	GameObject player;  // Reference to Charlie
	Rigidbody2D playerBody;


	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
		playerBody = player.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
			
	}

	// While charlie is on the conveyor add a speed to the right 
	void OnCollisionStay2D(Collision2D other){
		if (other.gameObject.CompareTag("Player")){
			playerBody.velocity = playerBody.velocity + Vector2.right * conveyorSpeed; 
		}

	}
}
