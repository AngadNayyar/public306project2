using UnityEngine;
using System.Collections;

public class Mincer : MonoBehaviour
{
    //speed at which the object moves back and forth
    public float speed = 3;
    //direction in which the object moves. 1 is for right and -1 for left
    public float dir = 1;

    void Update()
    {
        //move the object at a rate of 1*speed unit/s along the x-axis
        transform.Translate(new Vector3(1, 0, 0) * Time.deltaTime * dir * speed);
    }

    //check if the object hits the other two cubes
    void OnTriggerEnter2D(Collider2D coll)
    {
        //check if the object enter into a trigger with objects named Mincer
        if (coll.gameObject.tag == "Mincer")
        {
            //reverse the current direction 
            dir *= -1;
        }
    }

}