using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour {

	private Sprite[] bossHealth = new Sprite[6]; 
	private Archer Knight_Lord;
	private SpriteRenderer Boss_health_full;
	[SerializeField]
	private Sprite[] line1Sub; // an array of Sprite for the different size fonts
	[SerializeField]
	private Sprite[] line2Sub;
	private SpriteRenderer subSpawn;

	void Start () {

		for(int i =0; i<=5; i++){
			bossHealth [i] = Resources.Load <Sprite> ("Sprites/Boss Health/" + i);
		}
		
		Boss_health_full = gameObject.GetComponent<SpriteRenderer> ();
		Knight_Lord = GameObject.Find("Knight Lord").GetComponent<Archer> ();
		subSpawn = GameObject.Find ("SubtitleSpawn").GetComponent<SpriteRenderer> ();
		
	}


	void Update () { 
		switch (Knight_Lord.health) { 
		case 500:
			
			switch (GameManager.instance.fontSize) { // switch statment check what size the font for the subtitles should be and changes the subSpawn GameObjects Sprite - [Zak]

			case "Small":
				subSpawn.sprite = line1Sub[0];
				break;
			case "Medium":
				subSpawn.sprite = line1Sub[1];
				break;
			case "Large":
				subSpawn.sprite = line1Sub[2];
				break;
			}
			Boss_health_full.sprite = bossHealth [5];
			break;
		case 400:
			Boss_health_full.sprite = bossHealth [4];
			subSpawn.sprite = null;
			break;
		case 300:
			Boss_health_full.sprite = bossHealth [3];
			break;
		case 200:
			switch (GameManager.instance.fontSize) {

			case "Small":
				subSpawn.sprite = line2Sub[0];
				break;
			case "Medium":
				subSpawn.sprite = line2Sub[1];
				break;
			case "Large":
				subSpawn.sprite = line2Sub[2];
				break;
			}
			Boss_health_full.sprite = bossHealth [2];
			break;
		case 100:
			Boss_health_full.sprite = bossHealth [1];
			break;
		case 0:
			Boss_health_full.sprite = bossHealth [0];
			GameManager.instance.Victory ();
			break;
	}
}
}
