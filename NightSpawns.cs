using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightSpawns : MonoBehaviour {


	Vector3 spawnPosition;
	SpriteRenderer backgroundRenderer;
	[SerializeField]
	Sprite nightBackground;
	SpriteRenderer floorRenderer;
	[SerializeField]
	Sprite nightFloor;
	[SerializeField]
	Sprite nightForeground;
	SpriteRenderer[] foregroundRenderers;
	GameObject[] spawnPoints;
	[SerializeField]
	GameObject[] creatures;

	void Start()
	{
		backgroundRenderer = GameObject.Find ("Background").GetComponent<SpriteRenderer> ();
		floorRenderer = GameObject.Find ("Floor").GetComponent<SpriteRenderer> ();
		spawnPoints = GameObject.FindGameObjectsWithTag ("SpawnPoint");
		foregroundRenderers = GameObject.Find("Foreground").GetComponentsInChildren<SpriteRenderer>();

		if (GameManager.instance.nightTime) { // if its night time spawns night enermy's at specified spawn points using GameObjects

			for(int i= 0 ; i < spawnPoints.Length; i++){
				spawnPosition = new Vector3 (spawnPoints [i].transform.position.x, spawnPoints[i].transform.position.y, 0);
				Instantiate (creatures[Random.Range(0,creatures.Length-1)], spawnPosition, Quaternion.identity);
			}
			backgroundRenderer.sprite = nightBackground; // changes the background to a night background
			floorRenderer.sprite = nightFloor; // changes the floor to a night floor
			for (int i = 0; i < foregroundRenderers.Length; i++) {
				foregroundRenderers [i].sprite = nightForeground; // changes the foreground Sprites to their night sprites
			}
		}
	}

}
