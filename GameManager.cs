using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // using unity's SceneManagement

public enum GameState{menu, settings, tutorial, level_1, level_2, level_3, deathScreen, victoryScreen, credits}; // creating an enumuator outside of the class of a GameState Type

public class GameManager : MonoBehaviour {


	public static GameManager instance; // creates a static instance of itself making the class as singleton class
	public int health = 100;
	public int power = 0;
	public bool nightTime; 
	private DateTime now; // creates a DateTime Object
	public int level;
	[SerializeField]
	private GameObject optionsMenuPrefab;
	private GameObject optionsMenu;
	private GameObject musicObject;
	private AudioSource[] audioBGM; // creating an array of AudioSource for the two different Background music sorces
	public bool isMuted;
	public float musicVolume = 0.4f; // creates float property and assigns it a value
	public float sfxVolume = 0.4f;
	public int playerStrength;
	public string fontSize; // creating a string type object


	void Awake() 
	{
		if (instance == null) {
			instance = this;
			DontDestroyOnLoad (this);
		}
		now = DateTime.Now; // gets the current Date and Time


		if (now.Hour >= 18 || now.Hour <= 6) { // if its between 6 at night and 6 in the morning
			nightTime = true; // set nighttime to true
		} else {
			nightTime = false;
		}
	}

	private void Start(){

		fontSize = "Medium"; // sets the default subtitle size to medium
		musicObject = GameObject.FindGameObjectWithTag ("Music");
		audioBGM = musicObject.GetComponents<AudioSource> ();
	}


	public void BackToMenu() // a public method that can be caled to change the GameState
	{
		SetGameState (GameState.menu);
	}

	public void Settings()
	{
		SetGameState (GameState.settings);
	}

	public void Tutorial()
	{
		SetGameState (GameState.tutorial);
	}

	public void StartGame ()
	{
		SetGameState (GameState.level_1);
	}

	public void Level2()
	{
		SetGameState (GameState.level_2);
	}

	public void Level3 ()
	{
		SetGameState (GameState.level_3);
	}

	public void GameOver() 
	{
		SetGameState (GameState.deathScreen);
	}

	public void Victory()
	{
		SetGameState (GameState.victoryScreen);
	}

	public void Credits()
	{
		SetGameState (GameState.credits);
	}

	void SetGameState (GameState newGameState)
	{
		switch (newGameState) { // depending on what the game state is a different scene is loaded
		case GameState.menu: 
			SceneManager.LoadSceneAsync ("Main_Menu", LoadSceneMode.Single);
			break;
		case GameState.settings: 
			SceneManager.LoadSceneAsync ("Settings_Menu", LoadSceneMode.Single);
			break;
		case GameState.tutorial: 
			SceneManager.LoadSceneAsync ("Level_0", LoadSceneMode.Single);
			break;
		case GameState.level_1: 
			SceneManager.LoadSceneAsync ("Level_1", LoadSceneMode.Single);
			break;
		case GameState.level_2: 
			SceneManager.LoadSceneAsync ("Level_2", LoadSceneMode.Single);
			break;
		case GameState.level_3: 
			SceneManager.LoadSceneAsync ("Level_3", LoadSceneMode.Single);
			break;
		case GameState.deathScreen: 
			SceneManager.LoadSceneAsync ("Death_Screen", LoadSceneMode.Single);
			break;
		case GameState.victoryScreen:
			SceneManager.LoadSceneAsync ("Victory_Screen", LoadSceneMode.Single);
			break;
		case GameState.credits: 
			SceneManager.LoadSceneAsync ("Credits", LoadSceneMode.Single);
			break;
		}
	
	}

}
