using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {

    // PRIVATE INSTANCE VARIABLE +++++++++++++++++++++++
    public float speed;

	void Start ()
    {
        Rigidbody2D _rigidbody2D = GetComponent<Rigidbody2D>();
        // Set velocity for star shot
        _rigidbody2D.velocity = transform.right * speed;
    }
}
