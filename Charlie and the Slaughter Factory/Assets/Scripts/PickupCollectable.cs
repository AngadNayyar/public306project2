using UnityEngine;
using System.Collections;

/*
 * Destroys chicken objects when they are 'collected'
 */
public class PickupCollectable : MonoBehaviour
{
    // Upon colliding with the player the number of chickens collected
    // is incremented and the chicken object is destroyed
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("ChickenCollectable")) {
            int oldChickens = PlayerPrefs.GetInt("LevelCollectables");

            int newChickens = oldChickens + 1;
            PlayerPrefs.SetInt("LevelCollectables", newChickens);

            Destroy(other.gameObject);
        }
    }
}