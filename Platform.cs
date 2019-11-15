using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour {

	[SerializeField]
	private GameObject platform; // GameObject to refer to itself as without when the gameObject is removed from the heirachie the code stops running
	private bool active = true;
	private float timer = 0f;
	private float delay = 4f;

	void Update () 
	{
		if (timer < delay) {
			timer += Time.deltaTime;
		} else {
			if (active) { // if its ment to be active
				platform.SetActive (true); // sets the platform to be active in the scene

			} else {
				platform.SetActive (false); // sets the platform to be inactive in the scene
			}
			active = !active;
			timer = 0f;
		}
	}
}
