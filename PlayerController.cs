using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour {


	private Animator animator;
	private Vector3 startingPosition;
	private Rigidbody2D rigidBody;
	public bool attacking;
	private bool enermy;
	private bool isGrounded;
	private int numKeys;
	private float maxSpeed;
	private Jailer jailer;
	private SpriteRenderer robinRenderer;
	[SerializeField]
	private Sprite runRSprite;
	[SerializeField]
	private Sprite runLSprite;
	[SerializeField]
	private Sprite idle;
	[SerializeField]
	private Sprite attackSprite;
	public int health = 100;
	float attackTimer = 0f;
	[SerializeField]
	float coolDownTime = 0.1f;
	bool isMoving;
	private AudioSource jumpAudio; //audio source for the jumping - [Sam]
	private AudioSource walkingAudio; //audio source for walking - [Sam]
	private AudioSource[] audioSourceArray; //array containing the sound for both jumping and walking [Sam]
	public AudioSource damageAudio;//  [Zak]
	private AudioSource attackAudio; 
	private AudioSource jumpLandingAudio; 
	private AudioSource walkinggrassAudio;


	public bool Attacking{
		get{
			return attacking;
			}
		set{
			attacking = value;
		}
	}
	public int NumKeys{ get; set; }


	private void Jump() {

		float jumpForce = 3f;
		rigidBody.AddForce (Vector2.up * jumpForce, ForceMode2D.Impulse); // ForceMode2D.Impulse measn all the force is given at once
		animator.SetBool ("Jumping", true);
		jumpAudio.Play();// play jump audio
		}




	private void Walk (){

		float walkSpeed = 200f;
		rigidBody.AddForce ((Vector2.right * walkSpeed) * Input.GetAxis ("Horizontal"));
		if (Input.GetAxis ("Horizontal") > 0) {
			transform.localScale = new Vector3 (1, 1, 1);
		} else if (Input.GetAxis ("Horizontal") < 0) {
			transform.localScale = new Vector3 (-1, 1, 1); //flips the transform to flip the sprite and colliders.
		}
		isMoving = true;


		if (GameManager.instance.level == 1) { // if its level 1 play a different walking sound
			
			if (!walkinggrassAudio.isPlaying) {
				walkinggrassAudio.Play ();
			}
		}else {
				
				if (!walkingAudio.isPlaying) { //if walkingAudio is not playing then play - [Sam] 
					walkingAudio.Play (); //the walking audio plays - [Sam]
				}
			}
		}



	private void OnTriggerStay2D (Collider2D other){
		
		if (other.name == "Floor") {
			isGrounded = true;
		}

		if (other.name == "Jailer") {
			enermy = true;
		}
	}




	private void OnTriggerExit2D (Collider2D other){
		
		if (other.name == "Floor") {
			isGrounded = false;
		}

		if (other.name == "Jailer") {
			enermy = false;
		}
	}


	private void Start () {
		
		rigidBody = gameObject.GetComponent<Rigidbody2D> ();
		startingPosition = gameObject.transform.position;
		maxSpeed = 5f;
		robinRenderer = gameObject.GetComponent<SpriteRenderer> ();
		numKeys = 0;
		animator = gameObject.GetComponent<Animator> ();

		audioSourceArray = gameObject.GetComponents<AudioSource> (); //the array finds the audio sources - [Sam]

		jumpAudio = audioSourceArray [0]; //first part of the array containing the audio for jumping - [Sam]
		walkingAudio = audioSourceArray [1]; //second part of the array containing the audio for walking - [Sam]
		damageAudio = audioSourceArray[2]; // [zak]
		attackAudio = audioSourceArray [3]; 
		walkinggrassAudio = audioSourceArray[4]; 

		foreach (AudioSource audio in audioSourceArray) {
			audio.volume = GameManager.instance.sfxVolume;
		}

		}
		
	private void FixedUpdate () {

		Collider2D[] prisonerColliders; // locally assigned varibles
		Collider2D[] playerColliders;

		if (Input.GetKey(KeyCode.W)  && isGrounded ==true && isMoving){
			Jump ();
		}

		if (attackTimer < coolDownTime) 
		{
			attackTimer += Time.deltaTime;
		}

		if (Input.GetMouseButtonDown (0)  ) 
		{
			if (attackTimer > coolDownTime) 
			{
				attacking = true;
				animator.SetBool ("Attacking", true);
				attackTimer = 0f;
				attackAudio.Play ();
			}
		}else{
			attacking = false;
			animator.SetBool ("Attacking", false);
		}
			
		if (Input.GetAxis("Horizontal") != 0 ) {
			Walk ();
			animator.SetBool ("Walking", true);
		}

		if (Input.GetAxis ("Horizontal") == 0) { // if player isn't moving
			robinRenderer.sprite = idle;
			rigidBody.velocity = new Vector2 (0, 0);
			animator.SetBool("Walking", false);
			isMoving = false;
			walkingAudio.Stop (); // stops audio
			walkinggrassAudio.Stop ();
		}

		if (rigidBody.velocity.x > maxSpeed) {
			rigidBody.velocity = new Vector2 (maxSpeed, rigidBody.velocity.y); // restince the player to a max speed
		}

		if (rigidBody.velocity.x < -maxSpeed) {
			rigidBody.velocity = new Vector2 (-maxSpeed, rigidBody.velocity.y);
		}

		if (rigidBody.velocity.y < 0) {
			animator.SetBool ("Jumping", false);
		}
			
		if (GameObject.FindGameObjectWithTag("Prisoner")) {
			try{
				playerColliders = gameObject.GetComponents<Collider2D>();
				foreach(Collider2D collider in playerColliders){
					foreach (GameObject prisoner in GameObject.FindGameObjectsWithTag("Prisoner")){
						prisonerColliders = prisoner.GetComponents<Collider2D> ();
						Physics2D.IgnoreCollision (prisonerColliders[1], collider);
					}
				}}catch{
						Debug.Log("Not all prisoners have two coliders");
					}
			}

		robinRenderer.color = Color.white; // sets the players sprite back to white after taking damage
	}
		
}
