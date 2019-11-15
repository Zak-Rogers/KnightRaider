using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD : MonoBehaviour {

	private Sprite[] healthBar =new Sprite[11];
	private PlayerController player;
	private SpriteRenderer healthHud; 

	void Start () {

		for(int i =0; i<=10; i++){
			healthBar [i] = Resources.Load <Sprite> ("Sprites/Health/" + i*10);
		}
		healthHud = gameObject.GetComponent<SpriteRenderer> ();
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerController>();
	}


	void Update () {

		switch (player.health) {
		case 100:
			healthHud.sprite = healthBar [10];
			break;
		case 90:
			healthHud.sprite = healthBar [9];
			break;
		case 80:
			healthHud.sprite = healthBar [8];
			break;
		case 70:
			healthHud.sprite = healthBar [7];
			break;
		case 60:
			healthHud.sprite = healthBar [6];
			break;
		case 50:
			healthHud.sprite = healthBar [5];
			break;
		case 40:
			healthHud.sprite = healthBar [4];
			break;
		case 30:
			healthHud.sprite = healthBar [3];
			break;
		case 20:
			healthHud.sprite = healthBar [2];
			break;
		case 10:
			healthHud.sprite = healthBar [1];
			break;
		case 0:
			healthHud.sprite = healthBar [0];
			break;

		}

	}
}
