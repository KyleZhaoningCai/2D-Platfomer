/*
 * Project Name: Unity 2D Platformer. Player Controls a character to jump through platforms
 *   to collect coins and destroy enemies
 * File Name: CoinController.cs
 * Author's Name: Zhaoning Cai
 * Last Modified by: Zhaoning Cai
 * Date Last Modified: Oct 26th, 2015
 * Revision History: 6th version (Final version)
 */
using UnityEngine;
using System.Collections;

// This class is responsible for coin behaviour
public class CoinController : MonoBehaviour {

    // Destroy coin itself upon colliding with player and play a pick up sound
    void OnCollisionEnter2D (Collision2D otherCollider)
    {
        if (otherCollider.gameObject.CompareTag("Player"))
        {
            GameController.Instance.AddScore(10);
            Destroy(gameObject);
        }

    }
}
