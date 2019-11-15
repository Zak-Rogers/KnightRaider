using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPoint : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.name == "Player") {
			GameManager.instance.Victory ();
			GameManager.instance.playerStrength = 20;
		}
	}
}
