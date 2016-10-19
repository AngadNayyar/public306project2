using UnityEngine;
using System.Collections;

public class Claw_lookat_player : MonoBehaviour {

    public Transform target;

	// Update is called once per frame
	void Update () {
        Quaternion rotation = Quaternion.LookRotation(target.transform.position - transform.position, transform.TransformDirection(Vector3.up));
        transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);
	}
}
