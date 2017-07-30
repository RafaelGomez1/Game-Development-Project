using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    //Singleton para trigger y mas (Solo queremos un unico personage
    //por pantalla.
    public static PlayerControl sharedInstance;

    //Initial position of player
    private Vector3 startPosition;
    private Rigidbody2D rigidBody;
    public float jumpForce = 6.0f;
    public Animator animator;
    public float runningSpeed = 6.0f;
    public LayerMask groundLayerMask;
    private bool facingRight = true;

    public AudioSource jumping;

    void Awake()
    {
        sharedInstance = this;
        //recuperar variable del jugador para aplicar fisicas:
        startPosition = this.transform.position;
        rigidBody = GetComponent<Rigidbody2D>();
        facingRight = true;

        animator.SetBool("IsMove", false);
		animator.SetBool ("IsJump", false);
       

    }

    // Use this for initialization
    public void StartGame()
    {
        this.transform.position = startPosition;
        rigidBody.velocity = new Vector2(0,0);

    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        if (GameManager.sharedInstance.currentGameState == GameState.inTheGame)
        {
            if (IsOnTheFloor())
            {
                animator.SetBool("IsJump", false);
                Jump();
            }
            Move();
            Flip(horizontal);
        }

    }

    void Jump()
    {

        if (Input.GetKeyDown(KeyCode.W))
        {
            if (!GameManager.sharedInstance.RestrictMovement())
            {
                rigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                jumping.Play();
            }
        }
    }

    void Move()
    {

        if (Input.GetKey(KeyCode.D))
        { 
            rigidBody.velocity = new Vector2(runningSpeed, rigidBody.velocity.y);
            animator.SetBool("IsMove", true);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            rigidBody.velocity = new Vector2(-runningSpeed, rigidBody.velocity.y);
            animator.SetBool("IsMove", true);


        }
        else
        {
            animator.SetBool("IsMove", false);
        }

    }

	bool IsOnTheFloor(){
		if (Physics2D.Raycast (rigidBody.transform.position, Vector2.down, 1.3f, groundLayerMask.value)) {
			animator.SetBool ("IsJump", false);
			return true;
		} else {
			animator.SetBool ("IsJump", true);
			return false;
		}
	}

    void Flip(float horizontal)
    {
        if (horizontal > 0 && !facingRight || horizontal < 0 && facingRight)
        {
            facingRight = !facingRight;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }

    public void KillPlayer()
    {
        Debug.Log("Muerto");
        //GameManager.sharedInstance.GameOver();
        StartGame();
        
    }
}


