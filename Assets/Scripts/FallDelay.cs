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
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void OnCollisionEnter2D(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            rigidBody.isKinematic = false;
        }
    }
}
