using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePlatformController : MonoBehaviour {

    [HideInInspector]
    public bool facingRight = true;

    [HideInInspector]
    public bool jump = false;

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
        anim = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

        if (Input.GetButtonDown("Jump") && grounded)
        {
            jump = true;
        }
	}

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        anim.SetFloat("Speed", Mathf.Abs(horizontal));

        if (horizontal * rigidBody.velocity.x < maxSpeed)
        {
            rigidBody.AddForce(Vector2.right * horizontal * moveForce);
        }

        if (Mathf.Abs (rigidBody.velocity.x) > maxSpeed)
        {
            rigidBody.velocity = new Vector2 (Mathf.Sign(rigidBody.velocity.x) * maxSpeed, rigidBody.velocity.y);
        }

        if (horizontal > 0 && !facingRight)
        {
            Flip();
        }
        else if (horizontal < 0 && facingRight)
        {
            Flip();
        }

        if (jump)
        {
            anim.SetTrigger("Jump");
            rigidBody.AddForce(new Vector2(0f, jumpForce));
            jump = false;
        }
    }

    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

}


