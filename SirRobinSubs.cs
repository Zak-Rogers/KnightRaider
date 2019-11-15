using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SirRobinSubs : MonoBehaviour {

	[SerializeField]
	private Sprite smallSubtitle;
	[SerializeField]
	private Sprite mediumSubtitle;
	[SerializeField]
	private Sprite largeSubtitle;
	private bool showing;
	private float timer = 0f;
	[SerializeField]
	private float delay = 5f;


	void OnTriggerStay2D(){
		switch (GameManager.instance.fontSize) { // when player triggers the subtitle the sprite is changed depending on the size of the subtitles

		case "Small":
			gameObject.GetComponent<SpriteRenderer> ().sprite = smallSubtitle;
			showing = true; // set the showing bool to true
			break;
		case "Medium":
			gameObject.GetComponent<SpriteRenderer> ().sprite = mediumSubtitle;
			showing = true;
			break;
		case "Large":
			gameObject.GetComponent<SpriteRenderer> ().sprite = largeSubtitle;
			showing = true;
			break;
		}
	}

	void Update(){

		if (showing) { // if the subtitle is showing a timer is started to destroy the object after a set amount of time
			if (timer < delay) {
				timer += Time.deltaTime;
			} else {
				Destroy (gameObject);
			}
		}
	}
}
