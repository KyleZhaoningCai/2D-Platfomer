using UnityEngine;
using System.Collections;

public class CoinController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    // Destroy coin itself upon colliding with player
    void OnCollisionEnter2D (Collision2D otherCollider)
    {
        if (otherCollider.gameObject.CompareTag("Player"))
        {
            GameController.Instance.AddScore(10);
            Destroy(gameObject);
        }

    }
}
