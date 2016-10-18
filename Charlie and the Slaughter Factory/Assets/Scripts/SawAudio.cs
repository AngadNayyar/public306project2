using UnityEngine;
using System.Collections;

//This class uses a collider so that when Charlie walks within a certain distance of the saw,
//the audio for the saw will start.

public class SawAudio : MonoBehaviour {

	GameObject player;  // Reference to Charlie

	public int triggerDistance;
	private AudioClip sawSound; //This is the variable for the .wav file.
	private AudioSource source; //The audio source for the saw object.

	void Awake () {

		player = GameObject.FindGameObjectWithTag("Player"); //Sets Charlie to the player variable
		source = GetComponent<AudioSource> (); //Sets the saw audio source to the source variable
		sawSound = source.GetComponent<AudioClip>(); //Gets the AudioClip that is to be played from the source.
	}
	
	//The Update checks Charlie's distance from the saw, and if he is within the trigger distance specified and 
	//the source isn't already playing, then the AudioClip will be played.
	void Update () {

		//Get Charlie's x coordinate
		float player_pos = player.transform.position.x;

		if ((Mathf.Abs(player_pos - transform.position.x) < triggerDistance) && (!source.isPlaying)) {
			source.Play();
		}
	
	}
}