using UnityEngine;
using System.Collections;

public class Claw_follow_player : MonoBehaviour {

    public Transform player;
    public float speed = 4.0f;
    private Vector3 newPosition;
    private bool touchingWall = false;
    private GameObject Claws;
    private float yvalue;

    void Start()
    {
        Claws = GameObject.FindGameObjectWithTag("Claw");
        //EdgeCollider2D edge = Claws.GetComponent<EdgeCollider2D>();
        yvalue = Claws.transform.position.y;
    }
	
	void Update () {
        Quaternion rotation = Quaternion.LookRotation(player.transform.position - transform.position, transform.TransformDirection(Vector3.up));
        transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);

        newPosition = transform.position - (transform.right * speed * Time.deltaTime);
        newPosition.y = yvalue;
        transform.position = newPosition;
    }

    /*void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Claw")
        {
            print("touched edge");
        }
    }*/
}
