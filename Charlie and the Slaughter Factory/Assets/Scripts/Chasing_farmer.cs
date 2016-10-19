using UnityEngine;
using System.Collections;

public class Chasing_farmer : MonoBehaviour
{

    public float speed = 3.0f;

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.right * speed * Time.deltaTime;
    }
}
