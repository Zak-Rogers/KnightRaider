using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightSubtitle : MonoBehaviour { // class for the subtitles which are for nighttime only


	[SerializeField]
	private Sprite[] subtitle;
	private SpriteRenderer render;
	private float timer = 0f;
	private float delay = 5f;


	void Start(){ 

		render = gameObject.GetComponent<SpriteRenderer> ();
		if (GameManager.instance.nightTime) {
			switch (GameManager.instance.fontSize) {

			case "Small":
				render.sprite = subtitle [0];
				break;
			case "Medium":
				render.sprite = subtitle [1];
				break;
			case "Large":
				render.sprite = subtitle [2];
				break;
			}
		}
	}
	void Update () {
		
			if (timer < delay) {
				timer += Time.deltaTime;
			} else {
			render.enabled = false;
			}


		}
	}

