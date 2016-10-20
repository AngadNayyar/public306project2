using UnityEngine;
using System.Collections;

/*
 * This code controls the pendulum object.  
 * The variables are publically set from the inspector for a larger swing.  
 * 
 * To make a pendulum use the pendulum prefab.  
 * If adaptations to the pendulum object need to be made ensure that the pendulum has
 * a collider, a rigid body and a hinge joint where the axis of rotation occurs. 
 * The hinge joint position needs to be moved to where the rotation is occuring.  
 * 
 * Code adapted from free resource at http://www.youcontributegames.com/ 
 * Charlie and the Slaughter factory - Teven Studios
 * 
 */ 

public class Pendulum : MonoBehaviour
{
	// These variables are set via the constructor to change the height of the pendulum swing 
	public Rigidbody2D rb2d;
    public float leftPushRange;
    public float rightPushRange;
    public float velocityThreshold;
	private AudioSource source;

	// On starting get the rigidbody and angular velocity of the pendulum object. 
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
		rb2d.angularVelocity = velocityThreshold;
		source = GetComponent<AudioSource> ();
    }

    //Update is called by Unity every frame - call the push the pendulum function
    void Update()
    {
        Push();
    }

	// This function 
    public void Push()
    {
		// If the pendulum is on the right side, still within the range,
		// and the velocity is a positive (moving right) then set the velocity 
		// to the velocity threshold (to keep it moving to the right).  
		// (Note: positive velocity is movement to the right)

        if (transform.rotation.z > 0
            && transform.rotation.z < rightPushRange
			&& (rb2d.angularVelocity > 0)
			&& rb2d.angularVelocity < velocityThreshold)
        {
			source.Play ();
			rb2d.angularVelocity = velocityThreshold;
        }
		// If the pendulum is on the left side, still within the range,
		// and the velocity is a negative (moving left) then set the velocity 
		// to a negative velocity threshold (to keep it moving to the left).  
		// (Note: negative velocity is movement to the left)
        else if (transform.rotation.z < 0
            && transform.rotation.z > leftPushRange
			&& (rb2d.angularVelocity < 0)
			&& rb2d.angularVelocity > velocityThreshold * -1)
        {
			source.Play ();
			rb2d.angularVelocity = velocityThreshold * -1;
        }

    }
}
