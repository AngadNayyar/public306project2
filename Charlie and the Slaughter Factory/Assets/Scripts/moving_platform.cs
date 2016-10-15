using UnityEngine;
using System.Collections;

public class moving_platform : MonoBehaviour {

    Vector3 Pos1 = new Vector3(-4, 0, 0);
    Vector3 Pos2 = new Vector3(4, 0, 0);
    float speed = 1.0f;

    // Use this for initialization
    void Start () {}
	
	// Update is called once per frame
	void Update () {
        //transform.position = new Vector2(Mathf.PingPong(Time.time, 3), transform.position.y);
        double fraction = (Mathf.Sin(Time.time * speed) + 1.0) / 2.0;
        transform.position = Vector3.Lerp(Pos1, Pos2, (float)fraction);
    }
}
