using UnityEngine;
using System.Collections;

public class CollectableSpawn : MonoBehaviour
{

    public Transform[] collectibleSpawns;
    public GameObject collectible;

    // Use this for initialization
    void Start()
    {

        Spawn();
    }

    void Spawn()
    {
        for (int i = 0; i < collectibleSpawns.Length; i++)
        {
            int collectibleFlip = Random.Range(0, 2);
            if (collectibleFlip > 0)
                Instantiate(collectible, collectibleSpawns[i].position, Quaternion.identity);
        }
    }
}