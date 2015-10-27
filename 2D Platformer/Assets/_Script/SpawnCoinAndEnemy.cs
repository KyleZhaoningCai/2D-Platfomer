/*
 * Project Name: Unity 2D Platformer. Player Controls a character to jump through platforms
 *   to collect coins and destroy enemies
 * File Name: SpawnCoinAndEnemy.cs
 * Author's Name: Zhaoning Cai
 * Last Modified by: Zhaoning Cai
 * Date Last Modified: Oct 26th, 2015
 * Revision History: 6th version (Final version)
 */
using UnityEngine;
using System.Collections;

// This class is responsible for spawning coins and enemy on each platform
public class SpawnCoinAndEnemy : MonoBehaviour {

    // PUBLIC INSTNCE VARIABLES +++++++++++++++++++++
    public Transform[] spawnSpots;
    public GameObject coin;
    public GameObject enemy;

	// Use this for initialization
	void Start () {
        // Spawn coins and enemy
        Spawn();
	}
	
    // Spawn coins and enem
	void Spawn()
    {
        for (int i = 0; i < spawnSpots.Length; i++)
        {
            // On the spawn spot that's at the right edge of the platform
            if (i == 1)
            {
                // Three possibilities, so 1/3 chance for each possibilities
                int coinFlip = Random.Range(0, 3);
                
                // Chance of 1/3 that the spot will spawn a coin
                if (coinFlip == 0)
                {
                    Instantiate(coin, spawnSpots[i].position, Quaternion.identity);
                }
                // Chance of 2/3 that the spot will spawn an enemy
                else
                {
                    Instantiate(enemy, spawnSpots[i].position, Quaternion.identity);
                }
            }

            // On the spawn spots that are at the middle and left edge of the platform
            else
            {
                // Two possibilities, 1/2 chance for each possibilities
                int coinFlip = Random.Range(0, 2);

                // Chance of 1/2 that they will spawn a coin or nothing
                if (coinFlip == 0)
                {
                    Instantiate(coin, spawnSpots[i].position, Quaternion.identity);
                }
            }
            
        }
    }
}
