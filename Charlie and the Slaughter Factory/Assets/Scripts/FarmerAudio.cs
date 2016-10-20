using UnityEngine;
using System.Collections;

public class FarmerAudio : MonoBehaviour {

	GameObject farmer;  // Reference to Farmer
	public AudioClip normal;
	public AudioClip xmas;
	public AudioClip space;

	private AudioSource source; //The audio source for the saw object.
	private GameController gameController;

	void Awake () {

		farmer = GameObject.FindGameObjectWithTag("Farmer"); //Sets Charlie to the player variable
		source = GetComponent<AudioSource> (); //Sets the saw audio source to the source variable
		gameController = GameObject.Find("GameController").GetComponent<GameController>();

		if (gameController.getTheme () == "Normal") {
			source.clip = normal;
			source.Play ();
		} else if (gameController.getTheme () == "Xmas") {
			source.clip = xmas;
			source.Play ();
		} else {
			source.clip = space;
			source.Play ();
		}
	}
}
