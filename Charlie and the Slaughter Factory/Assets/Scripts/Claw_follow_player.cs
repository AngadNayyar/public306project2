using UnityEngine;
using System.Collections;

public class Claw_follow_player : MonoBehaviour {

    public Transform player;
    public float speed = 2.0f;
	
	// Update is called once per frame
	void Update () {
        //look at player
        Quaternion rotation = Quaternion.LookRotation(player.transform.position - transform.position, transform.TransformDirection(Vector3.up));
        transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);



        // movement towards player
        //transform.position -= transform.right * speed * Time.deltaTime;
	}
}
