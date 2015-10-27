/*
 * Project Name: Unity 2D Platformer. Player Controls a character to jump through platforms
 *   to collect coins and destroy enemies
 * File Name: Mover.cs
 * Author's Name: Zhaoning Cai
 * Last Modified by: Zhaoning Cai
 * Date Last Modified: Oct 26th, 2015
 * Revision History: 6th version (Final version)
 */
using UnityEngine;
using System.Collections;

// This class is responsible for moving the star shot by the player
public class Mover : MonoBehaviour {

    // PRIVATE INSTANCE VARIABLE +++++++++++++++++++++++
    public float speed;

	void Start ()
    {
        Rigidbody2D _rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        // Set velocity for star shot to move it towards the right
        _rigidbody2D.velocity = transform.right * speed;
  
    }


}
