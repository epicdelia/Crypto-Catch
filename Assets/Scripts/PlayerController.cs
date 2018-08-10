/*=============================================================================
 |  Class: Player Controller  
 |  Author:  Delia Lazarescu
 |  Description: Script to control the player's movement- jumping, colliding 
 *===========================================================================*/
using UnityEngine;
using System.Collections;
/** 
Class for controlling the player, Satoshi. 
**/

public class PlayerController : MonoBehaviour {
    
    //set a bunch of variables 
	public float moveSpeed;
	private float moveSpeedStore;
	public float speedMultiplier;

	public float speedIncreaseMilestone;
	private float speedIncreaseMilestoneStore;

	private float speedMilestoneCount;
	private float speedMilestoneCountStore;

	public float jumpForce;

	public float jumpTime;
	private float jumpTimeCounter;

	private bool stoppedJumping;
	private bool canDoubleJump;

    //using rigidbody and collider for interacting with other objects 
	private Rigidbody2D myRigidbody;
    private Collider2D myCollider;

    //for checking when player is on the ground 
	public bool grounded;
	public LayerMask whatIsGround;
	public Transform groundCheck;
	public float groundCheckRadius;

    //also need to make the player look like he is moving 
	private Animator myAnimator;
	public GameManager theGameManager;

    //sound effects 
	public AudioSource jumpSound;
	public AudioSource deathSound;

	// Use this for initialization
	void Start () {

        //get all the components 
		myRigidbody = GetComponent<Rigidbody2D>();

		myCollider = GetComponent<Collider2D>();

		myAnimator = GetComponent<Animator>();

        //initialize variables
		jumpTimeCounter = jumpTime;
		speedMilestoneCount = speedIncreaseMilestone;
		moveSpeedStore = moveSpeed;
		speedMilestoneCountStore = speedMilestoneCount;
		speedIncreaseMilestoneStore = speedIncreaseMilestone;
		stoppedJumping = true;
	}
	
	// Update is called once per frame
	void Update () {
        
		grounded = Physics2D.IsTouchingLayers(myCollider, whatIsGround);

		//can also use grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

        //if the position of the player is ahead of the milestone
		if(transform.position.x > speedMilestoneCount)
		{
            //then increase the count 
			speedMilestoneCount += speedIncreaseMilestone;
            //increase speed to make it more difficult after a certain point 
			speedIncreaseMilestone = speedIncreaseMilestone * speedMultiplier;
			moveSpeed = moveSpeed * speedMultiplier;
		}

		myRigidbody.velocity = new Vector2(moveSpeed, myRigidbody.velocity.y);

        //if the space is pressed or mouse clicked - to be able to use on android or on desktop
		if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
		{
            //if player is on the ground - touching a platform 
			if(grounded)
			{
                //then he is allowed to jump when the space is pressed or mouse clicked 
				myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce);
				stoppedJumping = false;
                //make a cool sound effect 
				jumpSound.Play();
			}

			if(!grounded && canDoubleJump)
			{
				myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce);
				jumpTimeCounter = jumpTime;
				stoppedJumping = false;
				canDoubleJump = false;
				jumpSound.Play();
			}
		}

        //if player is jumping and the the space is pressed or mouse clicked - to be able to use on android or on desktop
		if((Input.GetKey (KeyCode.Space) || Input.GetMouseButton(0)) && !stoppedJumping)
		{
            //decrease time of jump
			if(jumpTimeCounter > 0)
			{
				myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce);
				jumpTimeCounter -= Time.deltaTime;
			}
		}

        //when space or mouse click is released 
		if(Input.GetKeyUp (KeyCode.Space) || Input.GetMouseButtonUp(0))
        {
            //now stop the player from jumping 
			jumpTimeCounter = 0;
			stoppedJumping = true;
		}

        //if player is on a platform
		if(grounded)
		{
            // let him double jump 
			jumpTimeCounter = jumpTime;
			canDoubleJump = true;
		}

        //also make it look like he's actually moving 
		myAnimator.SetFloat ("Speed", myRigidbody.velocity.x);
		myAnimator.SetBool ("Grounded", grounded);
	}

    //if player runs into obstacle
	void OnCollisionEnter2D (Collision2D other)
	{
        //if player runs into those spikey objects 
		if(other.gameObject.tag == "killbox")
		{
            //player dies, game restarts, make a sad sound to show game is over
			theGameManager.RestartGame();
			moveSpeed = moveSpeedStore;
			speedMilestoneCount = speedMilestoneCountStore;
			speedIncreaseMilestone = speedIncreaseMilestoneStore;
			deathSound.Play();
		}
	}
}
