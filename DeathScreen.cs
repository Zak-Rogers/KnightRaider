using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathScreen : MonoBehaviour {


	public void RestartGame () {
		
		GameManager.instance.health = 100;
		GameManager.instance.power = 0;
		GameManager.instance.playerStrength = 20; // resets player stats before restarting the level

		switch (GameManager.instance.level) { // switch statement to select which GameManager.instance method to run depending on which level was just being played

		case 0: 
			GameManager.instance.Tutorial ();
			break;
		case 1:
			GameManager.instance.StartGame ();
			break;
		case 2:
			GameManager.instance.Level2 ();
			break;
		case 3:
			GameManager.instance.Level3 ();
			break;

		}
	}
	

	public void MainMenu () {
		
		GameManager.instance.health = 100; // rests health incase the user decides to going back into the game
		GameManager.instance.power = 0;
		GameManager.instance.BackToMenu();
	}
}
