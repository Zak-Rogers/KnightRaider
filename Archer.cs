using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer : Enermy { // Archer class inherants from Enermy class


	[SerializeField] // Allows Private variables be assigned in the inspector before running
	GameObject ammo; // creating a GameObject 
	GameObject arrow;
	PlayerController playerScript; // creating PlayerController Object to refrence the playerScript
	[SerializeField]
	Vector2 projectileSpawnPoint; // creating a Vector2 for the spawn cordinates

	void Start()
	{
		base.Start (); // runs the Start method from the Enermy class
	}

	public override void Walk ()
	{
		//Overrides the Walk method in the enermy class to stop the archer from moving
	}

	public override void Attack()  // Overrides the attack method in the Enermy class inorder to spawn a arrow
	{
		arrow = Instantiate (ammo, new Vector2(0,0), Quaternion.identity) as GameObject; // spawns ammo GameObject which is assigned in the inspector at 0,0 with 0 rotation and assigns to the arrow GameObject
		arrow.transform.parent = gameObject.transform; // assigns arrow Gameobject as a child of the current gameObject
		arrow.transform.localPosition = new Vector2(-3.57f,2.33f); // sets the location to a point above the crossbow
		AttackTimer = 0f;// resets attack timer in parent Enermy class
	}

	public override void OnTriggerStay2D(Collider2D other) // Overrides the OnTriggerStay2D from the Enermy class as the archer wont be causing the damage but the arrow will
	{
		if (other.name == "Player" && base.playerScript.Attacking == true) { // if the other colliders name is "Player" and the playerScript Object decared in the Enermy class is true
			base.playerScript.Attacking = false; // refering to the properties in the parent class
			base.TakeDamage ();
		}
	}
}