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

    public VelocityRange velocityRange = new VelocityRange(300f, 1000f);

    // PRIVATE INSTANCE VARIABLES ++++++++++++++++++++++++++++++++
    private Rigidbody2D _rigidBody2D;
    private Transform _transform;
    private Animator _animator;

    private AudioSource[] _audioSources;
    private AudioSource _coinSound;
    private AudioSource _jumpSound;

    private float _movingValue = 0;
    private bool _isFacingRight = true;
    private bool _isGrounded = true;

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
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        float absVelX = Mathf.Abs(this._rigidBody2D.velocity.x);
        float absVelY = Mathf.Abs(this._rigidBody2D.velocity.y);

        this._movingValue = Input.GetAxis("Horizontal"); // value is between -1 and 1

        this._animator.SetFloat("Speed", Mathf.Abs(this._movingValue));

        // Check if the player is moving
        if (this._movingValue != 0 ) // player is moving
        {
            this._animator.SetInteger("AnimeState", 1); // Play walk clip

            if (this._movingValue * this._rigidBody2D.velocity.x < this.velocityRange.vMax) // player is moving right
            {
                this._rigidBody2D.AddForce(Vector2.right * this._movingValue * speed);
            }

            if (absVelX > this.velocityRange.vMax)
            {
                this._rigidBody2D.velocity = new Vector2(Mathf.Sign(this._rigidBody2D.velocity.x) * this.velocityRange.vMax
                    , this._rigidBody2D.velocity.y);
            }
            
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
                
                this._rigidBody2D.AddForce(new Vector2(0f, jump));
                this._jumpSound.Play();
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
