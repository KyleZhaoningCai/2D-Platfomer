using UnityEngine;
using System.Collections;

public class SpawnCoinAndEnemy : MonoBehaviour {

    public Transform[] spawnSpots;
    public GameObject coin;
    public GameObject enemy;

	// Use this for initialization
	void Start () {
        Spawn();
	}
	
	void Spawn()
    {
        for (int i = 0; i < spawnSpots.Length; i++)
        {
            if (i == 1)
            {
                int coinFlip = Random.Range(0, 3);
                if (coinFlip == 0)
                {
                    Instantiate(coin, spawnSpots[i].position, Quaternion.identity);
                }
                else if (coinFlip == 1)
                {
                    Instantiate(enemy, spawnSpots[i].position, Quaternion.identity);
                }
            }
            else
            {
                int coinFlip = Random.Range(0, 2);
                if (coinFlip == 0)
                {
                    Instantiate(coin, spawnSpots[i].position, Quaternion.identity);
                }
            }
            
        }
    }
}
