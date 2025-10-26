using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerController : MonoBehaviour
{
    public static playerController instance;

    public float moveSpeed;
    public float jumpSpeed;
    public float doubleJumpSpeed;

    public bool canMove;


    public Rigidbody2D theRigidbody;
    public Transform groundCheck;

    public float groundCheckRadius;
    public LayerMask whatIsGround; // helps us identify what box colliders are considered ground.
    public bool onGround;
    public bool canDoubleJump;

    public Animator theAnim;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        theRigidbody = GetComponent<Rigidbody2D>();
        theAnim = GetComponent<Animator>();
        canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        //Ground Checking
        onGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround); // returns true if the drawn circle under player is touching any box colliders marked as ground

        //Player Movement
        if (canMove)
        {


            // Moving Right and Left
            if (Input.GetAxisRaw("Horizontal") > 0f) //player moving right
            {
                theRigidbody.velocity = new Vector3(moveSpeed, theRigidbody.velocity.y, 0f);
                transform.localScale = new Vector3(1f, 1f, 1f); // make player face right

            }
            else if (Input.GetAxisRaw("Horizontal") < 0f) //player moving left
            {
                theRigidbody.velocity = new Vector3(-moveSpeed, theRigidbody.velocity.y, 0f);
                transform.localScale = new Vector3(-1f, 1f, 1f); // make player face left
            }
            else
            {
                theRigidbody.velocity = new Vector3(0f, theRigidbody.velocity.y, 0f); // Player stops
            }

            // Jumping
            if (Input.GetButtonDown("Jump") && onGround)
            {
                theRigidbody.velocity = new Vector3(theRigidbody.velocity.x, jumpSpeed, 0f);
                canDoubleJump = true;
            }
            // Double Jumping
            if (Input.GetButtonDown("Jump") && !onGround && canDoubleJump)
            {
                theRigidbody.velocity = new Vector3(theRigidbody.velocity.x, doubleJumpSpeed, 0f);
                canDoubleJump = false;
                theAnim.SetTrigger("doubleJump");
            }
        }

            //Linking the animator's parameters so that the animations play when needed.
            theAnim.SetFloat("moveSpeed", Mathf.Abs(theRigidbody.velocity.x)); //used theRigidBody's velocity x (as it marks the current speed of player) and abs so that we don't have to deal with negative speeds(when the player is going left)
        theAnim.SetBool("onGround", onGround);

    }

    private void OnDrawGizmosSelected() // if the player is selected, show this gizmo
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }

    // functions to allow the character to move with a moving platform.
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "MovingPlatform")
        {
            transform.parent = other.transform;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "MovingPlatform")
        {
            transform.parent = null;
        }
    }

    // Functions to make player die when falling out of map limit

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "MapLimit")
        {
            gameManager.instance.currentHealth = 0;
            gameManager.instance.updateHealth();
        }
    }

    public void DeathState()
    {
        theRigidbody.simulated = false; //This disables charachter physics
        canMove = false; // This disables movement for player
        theAnim.SetTrigger("hasDied");
        gameManager.instance.GameOver();
    }
}
