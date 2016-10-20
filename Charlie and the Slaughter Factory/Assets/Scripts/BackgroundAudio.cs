using UnityEngine;
using System.Collections;

public class BackgroundAudio : MonoBehaviour {

	public AudioClip normal;
	public AudioClip xmas;
	public AudioClip space;

	private AudioSource source; //The audio source for the saw object.
	private GameController gameController;

	// Use this for initialization
	void Awake () {
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
