using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class CollectableSpawn : MonoBehaviour
{
	//This array is all of the spawn points and gets added in from the inspector.
	public List<Transform> collectibleSpawns = new List<Transform>();
    public GameObject collectible;

	public int fixedCollectibleNumber; //This means that there will always be exactly 10 collectible spawns per level.
	private int collectibleCount = 0; //Keeps track of how many collectibles have already been spawned.

    // Call spawn method to spawn a chicken
    void Start()
    {
        Spawn();
    }

    void Spawn()
    {
        
		while (collectibleCount < fixedCollectibleNumber) {

			//Loop through each spawn point and randomly generate a number which will decide whether a collectible
			//will be spawned or not.
			for (int i = collectibleSpawns.Count-1; i >= 0; i--)
			{
				//If the random number is greater than zero, instatiante the chicken.
				int collectibleFlip = UnityEngine.Random.Range(0, 4);
				if ((collectibleFlip > 2)&&(collectibleCount < fixedCollectibleNumber)) {
					Instantiate (collectible, collectibleSpawns [i].position, Quaternion.identity);
					collectibleCount = collectibleCount + 1; 
					collectibleSpawns.RemoveAt (i);
				}
			}
		}
    }
}