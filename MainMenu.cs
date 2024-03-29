using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour {


	public void StartGame()
	{
		GameManager.instance.StartGame (); // when user clicks start game button loads first level
		GameManager.instance.level = 1; // sets the level in GameManager to 1
	}

	public void Tutorial()
	{
		GameManager.instance.Tutorial ();
		GameManager.instance.level = 0;
	}

	public void Settings()
	{
		GameManager.instance.Settings ();
	}

	public void Exit()
	{
		Application.Quit ();
	}
}


