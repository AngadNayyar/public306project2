using UnityEngine;
using System.Collections;

/*
 * Destroys coins when they are 'collected'
 */
public class PickupCollectable : MonoBehaviour
{
    // Upon colliding with the player the object is destroyed
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
            Destroy(gameObject);
    }
}