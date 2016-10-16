using UnityEngine;
using System.Collections;


/*
 * This Script controls the camera following the character   
 * 
 * Charlie and the Slaughter factory - Teven Studios 
 * Adpated from the Unity 2D platformer sample project  
 */ 


public class CameraFollow : MonoBehaviour 
{
	private float xMargin = 2f;		// Distance in the x axis the player can move before the camera follows.
	private float yMargin = 2f;		// Distance in the y axis the player can move before the camera follows.
	private float xSmooth = 2f;		// How smoothly the camera catches up with it's target movement in the x axis.
	private float ySmooth = 2f;		// How smoothly the camera catches up with it's target movement in the y axis.
	private Vector2 maxXAndY = new Vector2(600, 560);		// The maximum x and y coordinates the camera can have.
	private Vector2 minXAndY = new Vector2(-10f, -2f);		// The minimum x and y coordinates the camera can have.

	private Transform player;		// Reference to the player's transform.


	void Awake ()
	{
		// Setting up the reference.
		player = GameObject.FindGameObjectWithTag("Player").transform;
	}


	bool CheckXMargin()
	{
		// Returns true if the distance between the camera and the player in the x axis is greater than the x margin.
		return Mathf.Abs(transform.position.x - player.position.x) > xMargin;
	}


	bool CheckYMargin()
	{
		// Returns true if the distance between the camera and the player in the y axis is greater than the y margin.
		return Mathf.Abs(transform.position.y - player.position.y) > yMargin;
	}


	void FixedUpdate ()
	{
		TrackPlayer();
	}


	void TrackPlayer ()
	{
		// By default the target x and y coordinates of the camera are it's current x and y coordinates.
		float targetX = transform.position.x;
		float targetY = transform.position.y;

		// If the player has moved beyond the x margin...
		if(CheckXMargin())
			// ... the target x coordinate should be a Lerp between the camera's current x position and the player's current x position.
			// (Lerp is a linear interpolation between two vectors)
			targetX = Mathf.Lerp(transform.position.x , player.position.x, xSmooth * Time.deltaTime);

		// If the player has moved beyond the y margin...
		if(CheckYMargin())
			// ... the target y coordinate should be a Lerp between the camera's current y position and the player's current y position.
			// (Lerp is a linear interpolation between two vectors )
			targetY = Mathf.Lerp(transform.position.y, player.position.y, ySmooth * Time.deltaTime);

		// The target x and y coordinates should not be larger than the maximum or smaller than the minimum.
		targetX = Mathf.Clamp(targetX, minXAndY.x, maxXAndY.x);
		targetY = Mathf.Clamp(targetY , minXAndY.y, maxXAndY.y);

		// Set the camera's position to the target position with the same z component.
		transform.position = new Vector3(targetX, targetY, transform.position.z);
	}
}
