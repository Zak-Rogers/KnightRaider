using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsScript : MonoBehaviour {

	public void MainMenu()
	{
		GameManager.instance.BackToMenu ();// takes the user back to the main menu
	}

	public void Exit()
	{
		Application.Quit (); // Exits the Game
	}
}
