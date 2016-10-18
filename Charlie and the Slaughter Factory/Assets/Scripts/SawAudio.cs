using UnityEngine;
using System.Collections;

//This class uses a collider so that when Charlie walks within a certain distance of the saw,
//the audio for the saw will start.

public class SawAudio : MonoBehaviour {

	GameObject player;  // Reference to Charlie
	public AudioClip sawSound; //This is the variable for the .wav file.

	private AudioSource source; 
	Rigidbody2D playerBody;
	Rigidbody2D sawBody;

	public int triggerDistance;

	void Awake () {

		player = GameObject.FindGameObjectWithTag("Player"); //Sets Charlie to the player variable
		source = GetComponent<AudioSource> (); //Sets the saw audio source to the source variable
		sawSound = source.GetComponent<AudioClip>();
		//playerBody = player.GetComponent<Rigidbody2D>();
		//sawBody = GetComponent<Rigidbody2D>();	
	
	}
	
	// Update is called once per frame
	void Update () {

		float player_pos = player.transform.position.x;

		if ((Mathf.Abs(player_pos - transform.position.x) < triggerDistance) && (!source.isPlaying)) {
			source.Play();
		}
	
	}
}