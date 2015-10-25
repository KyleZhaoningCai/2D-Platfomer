using UnityEngine;
using System.Collections;

public class SpawnManager : MonoBehaviour {

    public int maxPlatforms = 20;
    public GameObject platforms;
    public float horizontalMin = 6.5f;
    public float horizontalMax = 14f;
    public float verticalMin = 0f;
    public float verticalMax = 5f;

    private Vector2 relativePosition;
	// Use this for initialization
	void Start () {
        relativePosition = transform.position;
        Spawn();
	}
	
    void Spawn()
    {
        for (int i = 0; i < maxPlatforms; i++)
        {
            if (i%2 == 0)
            {
                Vector2 randomPosition = relativePosition + new Vector2(Random.Range(horizontalMin, horizontalMax), Random.Range(verticalMin, verticalMax));
                Instantiate(platforms, randomPosition, Quaternion.identity);
                relativePosition = randomPosition;
            }
            else
            {
                Vector2 randomPosition = relativePosition + new Vector2(Random.Range(horizontalMin, horizontalMax), Random.Range(verticalMin, -verticalMax));
                Instantiate(platforms, randomPosition, Quaternion.identity);
                relativePosition = randomPosition;
            }
            
        }
    }
}
