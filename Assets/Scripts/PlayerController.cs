using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;

    public float jumpTime;
    private float jumpTimeCounter;

    private Rigidbody2D myRigidBody;

    public bool grounded;
    public LayerMask whatIsGround;

    private Collider2D myCollider;

    private Animator myAnimator;

	// Use this for initialization
	void Start ()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<Collider2D>();
        myAnimator = GetComponent<Animator>();
        jumpTimeCounter = jumpTime;
	}
	
	// Update is called once per frame
	void Update ()
    {
        grounded = Physics2D.IsTouchingLayers(myCollider, whatIsGround);

        myRigidBody.velocity = new Vector2(moveSpeed, myRigidBody.velocity.y);

        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if (grounded)
            {
                myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, jumpForce);
            }
        }

        if(Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0))
        {
            if(jumpTimeCounter > 0)
            {
                myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, jumpForce);
                jumpTimeCounter -= Time.deltaTime;
            }
        }

        if(Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButtonUp(0))
        {
            jumpTimeCounter = 0;
        }

        if(grounded)
        {
            jumpTimeCounter = jumpTime;
        }

        myAnimator.SetFloat("Speed", myRigidBody.velocity.x);
        myAnimator.SetBool("Grounded", grounded);
	}
}
