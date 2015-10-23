using UnityEngine;
using System.Collections;

// VELOCITYRANGE UTILITY CLASS
[System.Serializable]
public class VelocityRange
{
    // PUBLIC INSTANCE VARIABLES +++++++++++++++++++++
    public float vMin, vMax;

    // CONSTRUCTOR +++++++++++++++++++++++++++++++++++
    public VelocityRange (float vMin, float vMax)
    {
        this.vMin = vMin;
        this.vMax = vMax;
    }
}

// PLAYERCONTROLLER CLASS
public class PlayerController : MonoBehaviour {

    // PUBLIC INSTANCE VARIABLES +++++++++++++++++++++++++++++++++
    public float speed = 50f;
    public float jump = 500f;

    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;


    public VelocityRange velocityRange = new VelocityRange(300f, 1000f);

    // PRIVATE INSTANCE VARIABLES ++++++++++++++++++++++++++++++++
    private Rigidbody2D _rigidBody2D;
    private Transform _transform;
    private Animator _animator;

    private AudioSource[] _audioSources;
    private AudioSource _coinSound;
    private AudioSource _jumpSound;
    private AudioSource _shotSound;

    private float _movingValue = 0;
    private bool _isFacingRight = true;
    private bool _isGrounded = true;

    private float nextFire;

    // Use this for initialization
    void Start () {
        // Refer to the rigidbody2D
        this._rigidBody2D = gameObject.GetComponent<Rigidbody2D>();
        // Refer to the transform
        this._transform = gameObject.GetComponent<Transform>();
        // Refer to the animator
        this._animator = gameObject.GetComponent<Animator>();
        // Refer too all audio sources attached to the player
        this._audioSources = gameObject.GetComponents<AudioSource>();
        // Refer to the coin sound
        this._coinSound = this._audioSources[0];
        // Refer to the jump sound
        this._jumpSound = this._audioSources[1];
        // Refer to the shooting sound
        this._shotSound = this._audioSources[2];
	}

    void Update ()
    {
        // Allow player to shoot star
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            // Set time for next fire
            nextFire = Time.time + fireRate;
            // Play Attack clip
            this._animator.SetInteger("AnimeState", 3);
            // Play shooting sound
            this._shotSound.Play();

            // If player is facing left, temporarily flip player to shoot star, then flip back
            if (!this._isFacingRight)
            {
                this._flip();
                // Instantiate a star GameObject
                Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
                this._flip();
            }
            // Otherwise, shoots star right away
            else
            {
                Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            }
        }
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        float absVelX = Mathf.Abs(this._rigidBody2D.velocity.x);
        float absVelY = Mathf.Abs(this._rigidBody2D.velocity.y);

        this._movingValue = Input.GetAxis("Horizontal"); // value is between -1 and 1


        // Check if the player is moving
        if (this._movingValue != 0 ) // player is moving
        {
            this._animator.SetInteger("AnimeState", 1); // Play run clip

            // Check if the player has less than max velocity
            if (this._movingValue * this._rigidBody2D.velocity.x < this.velocityRange.vMax) 
            {
                // move player in the correct direction with _movingValue.
                this._rigidBody2D.AddForce(Vector2.right * this._movingValue * speed);
            }

            // Check if the player has more than max velocity 
            if (absVelX > this.velocityRange.vMax)
            {
                // stop pushing the player
                this._rigidBody2D.velocity = new Vector2(Mathf.Sign(this._rigidBody2D.velocity.x) * this.velocityRange.vMax
                    , this._rigidBody2D.velocity.y);
            }
            
            // If the player is facing one way and it should move the other way, flip player.
            if (this._movingValue > 0 && !this._isFacingRight)
            {
                this._flip();
            }
            else if (this._movingValue < 0 && this._isFacingRight)
            {
                this._flip();
            }
        }
        else // player is idle
        {
            this._animator.SetInteger("AnimeState", 0); // Play idle clip
        }

        // Check if the player is jumping
        if (Input.GetKey("up") || Input.GetKey (KeyCode.W)) // player is jumping
        {
            // Check if the player is jumping
            if (this._isGrounded)
            {
                this._animator.SetInteger("AnimeState", 2); // Play jump clip
                
                // Move player along y axis
                this._rigidBody2D.AddForce(new Vector2(0f, jump));
                this._jumpSound.Play(); // play jump sound clip
                this._isGrounded = false;
                
            }
            
        }



    }

    // Plays a pick up coin sound when colliding with a coin gameobject
    void OnCollisionEnter2D(Collision2D otherCollider)
    {
        if (otherCollider.gameObject.CompareTag("Coin"))
        {
            this._coinSound.Play();
        }
    }

    // Check if a player is touching the platform
    void OnCollisionStay2D(Collision2D otherCollider)
    {
        if (otherCollider.gameObject.CompareTag("Platform"))
        {
            this._isGrounded = true;
        }
    }

    // PRIVATE METHODS ++++++++++++++++++++++++
    // Flips the player sprite
    private void _flip()
    {
        this._isFacingRight = !this._isFacingRight;
        Vector3 theScale = this._transform.localScale;
        theScale.x *= -1;
        this._transform.localScale = theScale;
    }
}
