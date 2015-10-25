using UnityEngine;
using System.Collections;

public class PlatformFall : MonoBehaviour {

    public float fallDelay = 1f;

    private Rigidbody2D _rigidbody2D;

	// Use this for initialization
	void Awake () {
        this._rigidbody2D = GetComponent<Rigidbody2D>();
	}
	


    void OnCollisionEnter2D (Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Invoke("Fall", fallDelay);
        }
    }

    void Fall()
    {
        this._rigidbody2D.isKinematic = false;
    }
}
