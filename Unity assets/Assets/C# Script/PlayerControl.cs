using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    private Rigidbody2D rigidBody;
    public float jumpForce = 6.0f;
    public Animator animator;
    public float runningSpeed = 6.0f;
    public LayerMask groundLayerMask;

    void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator.SetBool("IsMove", false);
		animator.SetBool ("IsJump", false);

    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        
		if (isOnTheFloor())
        {
			animator.SetBool ("IsJump", false);
            Jump();
        }
		Move();

    }



    void Jump()
    {

		if (Input.GetKeyDown (KeyCode.W)) {
			rigidBody.AddForce (Vector2.up * jumpForce, ForceMode2D.Impulse);
		}

    }

    void Move()
    {
		if (Input.GetKey (KeyCode.D)) {
			rigidBody.velocity = new Vector2 (runningSpeed, rigidBody.velocity.y);
			animator.SetBool("IsMove", true);

		} else if (Input.GetKey (KeyCode.A)) {
			rigidBody.velocity = new Vector2 (-runningSpeed, rigidBody.velocity.y);
			animator.SetBool("IsMove", true);

		} else {
			animator.SetBool("IsMove", false);
		}

    }

	bool isOnTheFloor(){
		if (Physics2D.Raycast (rigidBody.transform.position, Vector2.down, 1.3f, groundLayerMask.value)) {
			animator.SetBool ("IsJump", false);
			return true;
		} else {
			animator.SetBool ("IsJump", true);
			return false;
		}
	}
}


