using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

//This class randomly generates the collectibles from the list of spawn points.
public class CollectableSpawn : MonoBehaviour
{
	//This array is all of the spawn points and gets added in from the inspector.
	public List<Transform> collectibleSpawns = new List<Transform>();
    public GameObject collectible;
	public int fixedCollectibleNumber; //This variable is set in the inspector and determines how many collectibles
									   //will be found in the level.
	private int collectibleCount = 0; //Keeps track of how many collectibles have already been spawned.

    // Call spawn method to spawn the collectibles for the level.
    void Start()
    {
        Spawn();
    }

    void Spawn()
    {
        //This loop continues as long as the number of specified collectibles for the level has not yet been met.
		while (collectibleCount < fixedCollectibleNumber) {

			//Loop through each spawn point and randomly generate a number which will decide whether a collectible
			//will be spawned or not.
			for (int i = collectibleSpawns.Count-1; i >= 0; i--)
			{
				//If the random number is greater than zero, instatiante the collectible and remove that 
				//spawn point from the array so that it doesn't get used again. Also increment collectibleCount
				//so that we can keep track of how many collectibles have been instantiated.
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