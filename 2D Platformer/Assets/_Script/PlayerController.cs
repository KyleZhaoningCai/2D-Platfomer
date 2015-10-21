using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    // PRIVATE INSTANCE VARIABLES ++++++++++++++++++++++++++++++++
    private AudioSource[] _audioSources;
    private AudioSource _coinSound;

    // Use this for initialization
    void Start () {
        // Refer too all audio sources attached to the player
        this._audioSources = gameObject.GetComponents<AudioSource>();
        // Refer to the coin sound
        this._coinSound = this._audioSources[0];
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    // Plays a pick up coin sound when colliding with a coin gameobject
    void OnCollisionEnter2D(Collision2D otherCollider)
    {
        if (otherCollider.gameObject.CompareTag("Coin"))
        {
            this._coinSound.Play();
        }
    }
}
