using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour {

	public float moveSpeed;
	public float jumpForce;
	public bool grounded;
	public LayerMask whatIsGround;
	public Transform groundCheck;
	public float jumpTime;
	public float speedMultiplier;
	public float speedIncreaseMilestone;
	public float groundCheckRadious;

	private float speedMilestoneCount;
	private float jumpTimeCounter;
	private Rigidbody2D myRigidBody;
	private Animator myAnimator;
	public GameController gameController;
	private float moveSpeedStore;
	private float speedMilestoneCountStore;
	private float speedIncreaseMilestoneStore;

	public AudioSource jumpSound;
	public AudioSource deathSound1;
	public AudioSource deathSound2;
	public Swipe swipeControls;

	private bool stoppedJumping;
	private bool canDoubleJump;

	public bool isPunching;
	public float punchTime;
	public float betweenPunches;
	private float betweenPunchesStore;
	private float punchTimeStore;
	private float screenWidth;
	private GameObject pauseButton;

	// tap + swipe controll

	void Start () {

		myRigidBody = GetComponent<Rigidbody2D> ();
		myAnimator = GetComponent<Animator> ();
		jumpTimeCounter = jumpTime; 
		speedMilestoneCount = speedIncreaseMilestone;
		moveSpeedStore = moveSpeed;
		speedMilestoneCountStore = speedMilestoneCount;
		punchTimeStore = punchTime;
		speedIncreaseMilestoneStore = speedIncreaseMilestone;
		betweenPunchesStore = betweenPunches;
		stoppedJumping = true;
		isPunching = false;
		screenWidth = Screen.width;
		pauseButton = GameObject.Find ("PauseButton");

	}


	void Update () {
		
		if ( swipeControls.SwipeRight ) {

			if (grounded && betweenPunches <= 0) {
					isPunching = true;
					betweenPunches = betweenPunchesStore;
					jumpSound.Play ();
				}

			}

		if ( swipeControls.SwipeUp) {

			if (grounded) {

					myRigidBody.velocity = new Vector2 (myRigidBody.velocity.x, jumpForce);
					stoppedJumping = false;
					jumpSound.Play ();
				}

			//Double Jump
			/* if (!grounded && canDoubleJump) {

					myRigidBody.velocity = new Vector2 (myRigidBody.velocity.x, jumpForce);
					jumpTimeCounter = jumpTime;
					stoppedJumping = false;
					canDoubleJump = false;
					jumpSound.Play ();

				} */

			}
		//Double Jump
		/*
		if (swipeControls.Tap && !stoppedJumping) {

				if (jumpTimeCounter > 0) {

					myRigidBody.velocity = new Vector2 (myRigidBody.velocity.x, jumpForce);
					jumpTimeCounter -= Time.deltaTime;

				}

			}
		*/
		//End of Touch Section




		//Independent Section
		grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadious, whatIsGround);

		if (transform.position.x > speedMilestoneCount) {

			speedMilestoneCount += speedIncreaseMilestone;

			speedIncreaseMilestone = speedIncreaseMilestone * speedMultiplier;

			moveSpeed = moveSpeed * speedMultiplier;

		}

		myRigidBody.velocity = new Vector2 (moveSpeed, myRigidBody.velocity.y);


		if (grounded) {

			jumpTimeCounter = jumpTime;
			//canDoubleJump = true;

		}

		betweenPunches -= Time.deltaTime;

		if (isPunching == true) {

			punchTime -= Time.deltaTime;

			if (punchTime <= 0) {

				isPunching = false;
				punchTime = punchTimeStore;

			}
		}

		myAnimator.SetFloat ("Speed", myRigidBody.velocity.x);
		myAnimator.SetBool ("Grounded", grounded);
		myAnimator.SetBool ("Punching", isPunching);

		//End of Independent Section

	}
		

	void OnCollisionEnter2D (Collision2D other) {
	
		if (other.gameObject.tag == "Deathblock" && isPunching == false) {
			gameController.RestartGame ();
			moveSpeed = moveSpeedStore;
			speedMilestoneCount = speedMilestoneCountStore;
			speedIncreaseMilestone = speedMilestoneCountStore;
			deathSound1.Play ();
			Time.timeScale = 0f;
			pauseButton.SetActive (false);

		}
	}
}