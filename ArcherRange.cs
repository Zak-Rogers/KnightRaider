using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherRange : MonoBehaviour {


	Archer archer; // creating a Archer Object to reference to the archer script
	Animator animator; // creating a Animator Object to reference to the animator in script

	void Start () 
	{
		archer = gameObject.GetComponentInParent<Archer> (); // getting component from parent Gameobject
		animator = gameObject.GetComponentInParent<Animator> ();
	}
	
	void OnTriggerStay2D(Collider2D other)
	{
		if (other.name == "Player") {
			animator.SetBool("Attacking",true); // Setting a Bool withing the Animator component to true
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.name == "Player") {
			animator.SetBool ("Attacking", false);
		}
	}


}
