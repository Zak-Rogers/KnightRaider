using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

	private GameObject player;
	public float xMin;
	public float xMax;
	public float yMin;
	public float yMax;


	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
	}

	void LateUpdate () {
		float x = Mathf.Clamp (player.transform.position.x, xMin, xMax); // the camera Clamps onto the player so when the player moves the camera with keep them centered.
		float y = Mathf.Clamp (player.transform.position.y, yMin, yMax); // the min and max floats can be used to restrict the camera from going pass a certain point
		gameObject.transform.position = new Vector3 (x, y, gameObject.transform.position.z); // sets the camera's transform.position to a new Vector 3
	}
}
