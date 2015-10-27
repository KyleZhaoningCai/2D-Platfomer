/*
 * Project Name: Unity 2D Platformer. Player Controls a character to jump through platforms
 *   to collect coins and destroy enemies
 * File Name: EnemyController.cs
 * Author's Name: Zhaoning Cai
 * Last Modified by: Zhaoning Cai
 * Date Last Modified: Oct 26th, 2015
 * Revision History: 6th version (Final version)
 */
using UnityEngine;
using System.Collections;

// Responsible for enemy's behaviour
public class EnemyController : MonoBehaviour {

    
    //PUBLIC INSTANCE VARIABLES
    public float speed = 0.5f;

    

    //PRIVATE INSTANCE VARIABLES
    private Rigidbody2D _rigidbody2D;
    private Transform _transform;
    private Animator _animator;


    private bool _isGrounded = false;

    private float flipTime = 2.5f;
    private float nextFlip = 2.5f;
    private bool _isFacingRight = false;



    // Use this for initialization
    void Start () {
        this._rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        this._transform = gameObject.GetComponent<Transform>();
        this._animator = gameObject.GetComponent<Animator>();
        this._flip();

        
	}
	
	// Update is called once per frame
    void Update()
    {
        // If the game is over, allow user to restart by pressing "R" and reset game
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

	void FixedUpdate () {
        // Check whether it's time to make the enemy walk in different direction
        if (Time.time >= nextFlip)
        {
            this._flip();
            nextFlip += flipTime;
        }
        // Check if the enemy is grounded
        if (this._isGrounded)
        {
            // Make enemy walk left or right according to its facing
            if (this._isFacingRight)
            {
                this._animator.SetInteger("AnimeState", 1);
                this._rigidbody2D.velocity = new Vector2(this.speed, 0f);
            }
            else
            {
                this._animator.SetInteger("AnimeState", 1);
                this._rigidbody2D.velocity = new Vector2(-this.speed, 0f);
            }
        }
        // Enemy is idle if it doesn't touch the ground
        else
        {
            this._animator.SetInteger("AnimeState", 0);
        }

        
	}

    // Destroy player or reduce player's life
    void OnCollisionEnter2D(Collision2D otherCollider)
    {
        // Check if the enemy collides with the player'
        if (otherCollider.gameObject.CompareTag("Player"))
        {
            // If player has more than one life, then reduce the player's life only
            if (GameController.Instance.playerLife > 1)
            {
                GameController.Instance.ReduceLife();
                Destroy(this.gameObject);
            }
            // Otherwise, destroy the player after reducing player's life and game is over
            else
            {
                GameController.Instance.ReduceLife();
                Destroy(otherCollider.gameObject);
                Destroy(this.gameObject);
                GameController.Instance.GameOver();
            }
        }
    }

    // Check if the enemy is touching the platform
    void OnCollisionStay2D(Collision2D otherCollider)
    {
        if (otherCollider.gameObject.CompareTag("Platform"))
        {
            this._isGrounded = true;
        }
    }

    // Check if the enemy is leaving the platform
    void OnCollisionExit2D(Collision2D otherCollider)
    {
        if (otherCollider.gameObject.CompareTag("Platform"))
        {
            this._isGrounded = false;
        }
    }

    // Check if the enemy is shot by a star (enemy doesn't interact with death trigger because of layer)
    void OnTriggerEnter2D(Collider2D other)
    {
        // Each enemy kill gives player 20 points
        GameController.Instance.AddScore(20); 
        Destroy(other.gameObject, 1);
        Destroy(this.gameObject);
    }

    // Flip the enemy sprite
    private void _flip()
    {
        Vector3 theScale = this._transform.localScale;
        theScale.x *= -1;
        this._transform.localScale = theScale;
        this._isFacingRight = !this._isFacingRight;
    }
}
