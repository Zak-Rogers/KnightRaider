using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpPickUp : MonoBehaviour {


	PlayerController player;

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.name == "Player" && GameManager.instance.power <100) { // if other collider is player and the player power is below 100
			GameManager.instance.power += 25;
			Destroy (gameObject);
		}
	}
}
