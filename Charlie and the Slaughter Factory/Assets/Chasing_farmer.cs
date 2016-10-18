using UnityEngine;
using System.Collections;

public class Chasing_farmer : MonoBehaviour
{

    public float speed = 3.0f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.right * speed * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            print("Caught");
        }
    }
}
