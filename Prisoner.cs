	using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prisoner : MonoBehaviour {


	SpriteRenderer pRenderer;
	[SerializeField]
	Sprite lockedUp;
	[SerializeField]
	Sprite free;
	[SerializeField]
	Sprite walking;
	PlayerController player;
	bool freed;
	Rigidbody2D rigidBody;
	float maxSpeed;


	void Start () {

		pRenderer = gameObject.GetComponent<SpriteRenderer> ();
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerController> ();
		rigidBody = gameObject.GetComponent<Rigidbody2D> ();
		maxSpeed = 5f;
	}

	void FixedUpdate () {

		if (freed) { // if prisoner is freed move to the left
			pRenderer.sprite = walking;
			gameObject.transform.localScale= new Vector3 (-1, 1, 1);
			rigidBody.AddForce (Vector2.left * 8f);
		}

		if (rigidBody.velocity.x > maxSpeed) {
			rigidBody.velocity = new Vector2 (maxSpeed, rigidBody.velocity.y);
		}
	}

	void OnTriggerEnter2D(Collider2D other){

		if (other.name == "Player") {

			if (player.NumKeys >0) { // if a player triggers the collider of the prisoner and has more than 0 keys

				pRenderer.sprite = free; // sprite chages to freed prisoner
				freed = true; // sets freed bool to true

				player.NumKeys--; // minus one key from the number of keys the player had
			}
		}
	}
}
