using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDelay : MonoBehaviour {

    public float fallDelay = 1;

    private Rigidbody2D rigidBody;

	// Use this for initialization
	void Awake ()
    {
        rigidBody = GetComponent<Rigidbody2D>();
	}


    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Invoke("Fall", fallDelay);
        }
    }

    private void Fall()
    {
        rigidBody.isKinematic = false;
    }

}
