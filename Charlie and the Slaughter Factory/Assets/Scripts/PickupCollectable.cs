using UnityEngine;
using System.Collections;

/*
 * Destroys coins when they are 'collected'
 */
public class PickupCollectable : MonoBehaviour
{
    // Upon colliding with the player the number of coins is incremented
    // and the coin object is destroyed
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player")) {
            int oldCoins = PlayerPrefs.GetInt("LevelChickens");
            int newCoins = oldCoins + 1;
            PlayerPrefs.SetInt("LevelChickens", newCoins);
            Destroy(gameObject);
        }
    }
}