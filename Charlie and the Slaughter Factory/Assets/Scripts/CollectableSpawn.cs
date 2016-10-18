using UnityEngine;
using System.Collections;

public class CollectableSpawn : MonoBehaviour
{
	//This array is all of the spawn points and gets added in from the inspector.
	public Transform[] collectibleSpawns;
    public GameObject collectible;

	private int fixedCollectibleNumber = 10; //This means that there will always be exactly 10 collectible spawns per level.
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
			for (int i = 0; i < collectibleSpawns.Length; i++)
			{
				//If the random number is greater than zero, instatiante the chicken.
				int collectibleFlip = Random.Range(0, 2);
				if (collectibleFlip > 0) {
					Instantiate (collectible, collectibleSpawns [i].position, Quaternion.identity);
					collectibleCount = collectibleCount + 1; 
				}
			}
		}
    }
}