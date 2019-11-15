using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enermy : MonoBehaviour {


	public float distanceBuffer = 6;
	public int attractionDistance = 15;
	public Vector2 distance;
	public GameObject player;
	public Vector2 playerPosition;
	public Vector2 currentPosition;
	public float speed = 2f;
	public Animator animator;
	float attackTimer = 0f;
	public float coolDownTime = 4f;
	public SpriteRenderer playerSprite;
	[SerializeField]
	int strength = 10;
	public PlayerController playerScript;
	public SpriteRenderer enermySprite;
	[SerializeField]
	public int health = 100;
	private Animator playerAnimator;


	public float AttackTimer{ get; set; } // public Get;Set; for a private property 
	public int Strength{ get; set; }
	public int Health { get; set; }



	protected void Start () 
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		animator = gameObject.GetComponent<Animator> ();
		playerSprite = player.GetComponent<SpriteRenderer> ();
		playerScript = player.GetComponent<PlayerController> ();
		enermySprite = gameObject.GetComponent<SpriteRenderer> ();
		playerAnimator = GameObject.Find ("Player").GetComponent<Animator> ();
	}
	

	void FixedUpdate () 
	{
		Walk ();// called the Walk method of the class
		enermySprite.color = Color.white; // returns sprite to white after beign turned red when taking damage
		if (GameObject.Find ("Arrow(Clone)")) {// if GameObject "Arrow(Clone)" exsists
			Physics2D.IgnoreCollision (GameObject.Find("Arrow(Clone)").GetComponent<Collider2D> (), gameObject.GetComponent<Collider2D> ()); // ignore any collisions between arrows and enermy charaters
		}


	}


	public virtual new void Walk () // public virtual method means it can be over writen in a child class
	{
		playerPosition = new Vector2 (player.transform.position.x + distanceBuffer, player.transform.position.y); // gets player transform x postion and adds a distanceBuffer to it, gets the players y position assigns to x,y in Vector2 Object
		currentPosition = new Vector2 (gameObject.transform.position.x,0);
		distance = currentPosition - playerPosition; // calcuates distance between player and enermy
		if (distance.x < attractionDistance && distance.x > 0) {	// if the distance between the two is less than the attractionDistance and is greater than 0		
			gameObject.transform.position = Vector2.MoveTowards (currentPosition, playerPosition, speed * Time.deltaTime); // moves the enermy gameObject towards the player at an assigned speed

			animator.SetBool ("Walking", true);
			animator.SetBool ("Attacking", false);
		}

		if (distance.x <= 0.1f) {
			animator.SetBool ("Walking", false);
		}
	}

	public virtual void Attack()
	{
		if (attackTimer < coolDownTime) 
		{
			attackTimer += Time.deltaTime;
		}
		if (attackTimer > coolDownTime) {
			if (playerAnimator.GetBool ("Enhanced")) { 
				GameManager.instance.health -= strength / 2; 
			} else {
				GameManager.instance.health -= strength;
			}
			animator.SetBool ("Attacking", false);
			attackTimer = 0f;
			playerSprite.color = Color.red;
			playerScript.damageAudio.Play (); // plays the audio for the player taking damage
		}
	}

	protected void TakeDamage() // protected methods are private but access able by children classes
	{
		enermySprite.color = Color.red;
		health -= GameManager.instance.playerStrength; // enermy health - player strength
		if (health <= 0) {
			Death ();
		}
	}

	public virtual void Death ()
	{
		Destroy(gameObject);
	}

	public virtual void OnTriggerStay2D(Collider2D other)
	{
		if (other.name == "Player" && playerScript.Attacking == true) {
			playerScript.Attacking = false;	
			TakeDamage ();
		} 

		if (other.name == "Player") 
		{
			animator.SetBool ("Attacking", true);
			Attack ();
			animator.SetBool ("Walking", false);
		}
	}

}
