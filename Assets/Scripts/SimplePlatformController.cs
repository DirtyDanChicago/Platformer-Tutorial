using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePlatformController : MonoBehaviour {

    [HideInInspector]
    public bool facingRight = true;

    [HideInInspector]
    public bool jump = true;

    public float moveForce = 365f;
    public float maxSpeed = 5f;
    public float jumpForce = 1000f;
    public Transform groundCheck;

    private bool grounded;
    private Animator anim;
    private Rigidbody2D rigidBody;

    // Use this for initialization
    void Awake ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
