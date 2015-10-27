/*
 * Project Name: Unity 2D Platformer. Player Controls a character to jump through platforms
 *   to collect coins and destroy enemies
 * File Name: SpawnManager.cs
 * Author's Name: Zhaoning Cai
 * Last Modified by: Zhaoning Cai
 * Date Last Modified: Oct 26th, 2015
 * Revision History: 6th version (Final version)
 */
using UnityEngine;
using System.Collections;

// This class is responsible for spawning platforms randomly
public class SpawnManager : MonoBehaviour {

    // PUBLIC INSTANCE VARIABLES ++++++++++++++++++++++++++++++
    public int maxPlatforms = 20;
    public GameObject platforms;
    public float horizontalMin = 6.5f;
    public float horizontalMax = 14f;
    public float verticalMin = 1f;
    public float verticalMax = 5f;

    // PRIVATE INSTANCE VARIABLES +++++++++++++++++++++++++++++
    private Vector2 relativePosition;

	// Use this for initialization
	void Start () {

        // Spawn all 20 platforms
        relativePosition = transform.position;
        Spawn();
	}
	
    // Responsible for spawning 20 platforms
    void Spawn()
    {
        for (int i = 0; i < maxPlatforms; i++)
        {
            // Spawn platforms higher than the previous one at a random position
            if (i%2 == 0)
            {
                Vector2 randomPosition = relativePosition + new Vector2(Random.Range(horizontalMin, horizontalMax), Random.Range(verticalMin, verticalMax));
                Instantiate(platforms, randomPosition, Quaternion.identity);
                relativePosition = randomPosition;
            }
            // Spawn platforms lower than the previous one at a random position
            else
            {
                Vector2 randomPosition = relativePosition + new Vector2(Random.Range(horizontalMin, horizontalMax), Random.Range(-verticalMin, -verticalMax));
                Instantiate(platforms, randomPosition, Quaternion.identity);
                relativePosition = randomPosition;
            }
            
        }
    }
}
