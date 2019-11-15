using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jailer : Enermy {

	[SerializeField]
	GameObject lootDrop;


	public override void Death() // overriders the death method of the enermy class so when a jailer dies they drop a key
	{
		Vector2 spawnLocation = new Vector2 ((transform.position.x + 2f), (transform.position.y - 4.7f));
		Instantiate (lootDrop, spawnLocation, Quaternion.identity);
		Destroy(gameObject);
	}

//	void LateUpdate()
//	{
//		if (base.enermySprite.isVisible) {
//			Debug.Log ("We have your Citizens prisonner! Surrender now!");
//		}
//	}
}
