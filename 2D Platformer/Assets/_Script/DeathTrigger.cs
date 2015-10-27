/*
 * Project Name: Unity 2D Platformer. Player Controls a character to jump through platforms
 *   to collect coins and destroy enemies
 * File Name: DeathTrigger.cs
 * Author's Name: Zhaoning Cai
 * Last Modified by: Zhaoning Cai
 * Date Last Modified: Oct 26th, 2015
 * Revision History: 6th version (Final version)
 */
using UnityEngine;
using System.Collections;

// This class is responsible for detecting player falling off from the play area and killing the player
public class DeathTrigger : MonoBehaviour {

	// Update is called once per frame
	void Update () {

        // If game is over, allow player to press R to restart while resetting everything
        if (GameController.Instance.gameOver)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Application.LoadLevel(Application.loadedLevel);
                GameController.Instance.Reset();
                GameController.Instance.GameOver();
            }
        }
    }

    // If player fall down and touch the death trigger, the player is killed and game is over
    // no matter how many lives player still has
    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(other.gameObject);
            for (int i = 0; i < GameController.Instance.playerLife; i++)
            {
                GameController.Instance.ReduceLife();
            }
            GameController.Instance.ReduceLife();
            GameController.Instance.GameOver();
        }
        
    }
}
