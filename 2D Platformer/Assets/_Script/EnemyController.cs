using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

    
    //PUBLIC INSTANCE VARIABLES
    public float speed = 0.5f;
    public AnimationClip death;
    

    //PRIVATE INSTANCE VARIABLES
    private Rigidbody2D _rigidbody2D;
    private Transform _transform;
    private Animator _animator;

    private bool _isGrounded = false;

    private float flipTime = 3;
    private float nextFlip = 3;
    private bool _isFacingRight = false;



    // Use this for initialization
    void Start () {
        this._rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        this._transform = gameObject.GetComponent<Transform>();
        this._animator = gameObject.GetComponent<Animator>();
        this._flip();
        
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	    // Check if the enemy is grounded
        if (Time.time >= nextFlip)
        {
            this._flip();
            nextFlip += flipTime;
        }
        if (this._isGrounded)
        {
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
        else
        {
            this._animator.SetInteger("AnimeState", 0);
        }

        
	}

    void OnCollisionEnter2D(Collision2D otherCollider)
    {
        if (otherCollider.gameObject.CompareTag("Player"))
        {
            if (GameController.Instance.life > 1)
            {
                GameController.Instance.ReduceLife();
                Destroy(this.gameObject);
            }
            else
            {
                Destroy(otherCollider.gameObject);
                Destroy(this.gameObject);
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

    // Check if the enemy is touching the platform
    void OnCollisionExit2D(Collision2D otherCollider)
    {
        if (otherCollider.gameObject.CompareTag("Platform"))
        {
            this._isGrounded = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        
        GameController.Instance.AddScore(20); 
        Instantiate(death, this._transform.position, this._transform.rotation);
        Destroy(other.gameObject, 1);
        Destroy(this.gameObject);
    }

    private void _flip()
    {
        Vector3 theScale = this._transform.localScale;
        theScale.x *= -1;
        this._transform.localScale = theScale;
        this._isFacingRight = !this._isFacingRight;
    }
}
