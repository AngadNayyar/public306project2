using UnityEngine;
using System.Collections;

public class Claw_follow_player : MonoBehaviour {

    public Transform target;
    public float speed = 2.0f;
	
	// Update is called once per frame
	void Update () {
        Quaternion rotation = Quaternion.LookRotation(target.transform.position - transform.position, transform.TransformDirection(Vector3.up));
        transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);
        transform.position -= transform.right * speed * Time.deltaTime;
	}
}
