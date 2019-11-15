using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {


	Rigidbody2D rigidbody; // creating a Rigidbody2D Object to reference the Rigidbody2D.
	float timer = 0f; // float for a timer
	float decayTime = 0.1f;
	SpriteRenderer playerSprite; // creating a SpriteRenderer Object to refer to the SpriteRenderer
	[SerializeField]
	int strength = 10; // int for the strength of the arrow
	private Animator playerAnimator; 


	void Start () 
	{
		rigidbody = gameObject.GetComponent<Rigidbody2D> ();
		playerSprite = GameObject.Find ("Player").GetComponent<SpriteRenderer> ();
		playerAnimator = GameObject.Find ("Player").GetComponent<Animator> ();
	}

	void LateUpdate() // Using LateUpdate as the gameObject has a Rigidbody attached
	{
		rigidbody.AddForce (Vector2.left * Time.deltaTime); // adding a force to the Rigidbody towards the left * Time.deltaTime to make it move over a period of time
	}

	void OnTriggerStay2D(Collider2D other)
	{
		if (other.name == "Player") {
			if (timer < decayTime) { //timer for how long the arrow shows after hitting the player before beign destroyed
				timer += Time.deltaTime;
			}
			if (timer > decayTime) {
				
				if (playerAnimator.GetBool ("Enhanced")) { // Gets a bool from an Animator component
					GameManager.instance.health -= strength / 2; // if player has activated power up the player will take half damage
				} else {
					GameManager.instance.health -= strength; // refrenceing to the GameManager's instance and minusing the strenght of the arrow from the health of the player
				}
				 
				playerSprite.color = Color.red; // changed the player SpriteRenderer to red
				Destroy (gameObject); // destorys arrow gameObject
				timer = 0f; // reset timer
			}

		}
	}

}
