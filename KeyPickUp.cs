using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickUp : MonoBehaviour {

	PlayerController player;
	
	void OnTriggerEnter2D(Collider2D other){

		if (other.name == "Player") {

			player = other.GetComponent<PlayerController> ();

			if (player.NumKeys < 4) {

				player.NumKeys++;
			}
			Destroy (gameObject);
		}


	}
}
