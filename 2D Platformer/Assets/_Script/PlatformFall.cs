/*
 * Project Name: Unity 2D Platformer. Player Controls a character to jump through platforms
 *   to collect coins and destroy enemies
 * File Name: PlatformFall.cs
 * Author's Name: Zhaoning Cai
 * Last Modified by: Zhaoning Cai
 * Date Last Modified: Oct 26th, 2015
 * Revision History: 6th version (Final version)
 */
using UnityEngine;
using System.Collections;

// This class is responsible to make platforms fall 1 second after player touch the platforms
public class PlatformFall : MonoBehaviour {

    // PUBLIC INSTANCE VARIABLES +++++++++++++++++++++++++
    public float fallDelay = 1f;

    // PRIVATE INSTANCE VARIABLES ++++++++++++++++++++++++
    private Rigidbody2D _rigidbody2D;

	// Use this for initialization
	void Awake () {
        this._rigidbody2D = GetComponent<Rigidbody2D>();
	}
	
    // After making contact with the player, falls after 1 sec
    void OnCollisionEnter2D (Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Invoke("Fall", fallDelay);
        }
    }

    // Make platforms able to fall
    void Fall()
    {
        this._rigidbody2D.isKinematic = false;
    }
}
