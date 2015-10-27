/*
 * Project Name: Unity 2D Platformer. Player Controls a character to jump through platforms
 *   to collect coins and destroy enemies
 * File Name: GameController.cs
 * Author's Name: Zhaoning Cai
 * Last Modified by: Zhaoning Cai
 * Date Last Modified: Oct 26th, 2015
 * Revision History: 6th version (Final version)
 */
using UnityEngine;
using System.Collections;

// This class is responsible for game scoring and player life calculation logic
public class GameController : MonoBehaviour {

    // Allow instances of this class to be used by other classes
    private static GameController _instance;
    public static GameController Instance { get { return _instance ?? (_instance = new GameController()); } }

    // PUBLIC INSTANCES VARIABLES (can only be set by this class) +++++
    public int points { get; private set; }
    public string life { get; private set; }
    public int playerLife { get; private set; }
    public bool gameOver { get; private set; }

    // CONSTRUCTOR -- Initialize game stats
    private GameController() {
        this.points = 0;
        this.playerLife = 3;
        this.life = "Life : 3";
        gameOver = false;
    }

    // Add newScoreValue points to the points variable
	public void AddScore (int newScoreValue)
    {
        this.points += newScoreValue;
    }

    // Reduce player's lives by 1 and modify the life information or game over information
    public void ReduceLife()
    {
        this.playerLife -= 1;
        
        // if player has no more life, game is over
        if (this.playerLife <= 0)
        {
            this.life = "Game Over! Press 'R' to Start Over!";
        }
        else
        {
            this.life = "Life: " + this.playerLife;
        }
    }
    
    // Reset the game stats
    public void Reset()
    {
        this.points *= 0;
        this.playerLife += 3;
        this.life = "Life : 3";
    }

    // Set the game state to be over or ready
    public void GameOver()
    {
        this.gameOver = !this.gameOver;
    }

}
