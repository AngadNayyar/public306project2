using UnityEngine;
using System.Collections;
/**
 * This class is used by the farmer to move him at a constant velocity right from his starting position
 * 
 * Charlie and the Slaughter Factory : Teven Studios
 * */
public class Chasing_farmer : MonoBehaviour
{
    //speed of the farmer
    public float speed = 3.0f;

    //makes the farmer move at a constant speed right
    void Update()
    {
        transform.position += transform.right * speed * Time.deltaTime;
    }
}
