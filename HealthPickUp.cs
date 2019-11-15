using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUp : MonoBehaviour {


	PlayerController player;

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.name == "Player" && GameManager.instance.health<100) {
			GameManager.instance.health += 10;
			Destroy (gameObject);
		}
	}
}
