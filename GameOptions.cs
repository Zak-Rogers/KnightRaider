using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // using unity's UI
using UnityEngine.SceneManagement;

public class GameOptions : MonoBehaviour {
	 
	private GameObject MusicObject; 
	private AudioSource[] audioBGM;
	private bool isMuted;
	[SerializeField]
	private Slider musicSlider; // creating a Slider Object to refer to the slider UI on the setting page
	[SerializeField]
	private Slider sfxSlider;
	private GameObject[] audioGameObjects;
	private AudioSource[] sfxAudioSources;
	[SerializeField]
	private GameObject player;

	void Awake(){ // Awake runs when the game is loaded up were as start is when the object is created in the scene ingame

		SceneManager.sceneLoaded += OnSceneLoaded; // once the scene has loaded load OnSceneLoad
	}


	void OnSceneLoaded(Scene scene, LoadSceneMode mode){ // runs each time a scene is loaded
		MusicObject = GameObject.FindGameObjectWithTag ("Music");
		audioBGM = MusicObject.GetComponents<AudioSource>();
		audioBGM[0].volume = GameManager.instance.musicVolume; // assigning the volume of the BackGroundMusic to the music volume set in the Game Manager
		audioBGM[1].volume = GameManager.instance.musicVolume;

		if (!GameManager.instance.nightTime) { // if its day time
			audioBGM [1].mute = true; // mute the nighttime background music
		}

		sfxAudioSources = player.GetComponents<AudioSource> ();
		foreach (AudioSource audio in sfxAudioSources) { // loops through the sfxAudioSources array setting the volume for each audiosource to the value set in the game manager
			audio.volume = GameManager.instance.sfxVolume;
		}
		if (GameManager.instance.isMuted == true){ // if the game is ment to be muted
			audioBGM[0].mute=true; // mute background music
			audioBGM[1].mute=true;
			foreach (AudioSource audio in sfxAudioSources) { // loop through and mute sfxmusic
				audio.mute = true;
			}
		}
	}
		
	void Start ()
	{
		MusicObject = GameObject.FindGameObjectWithTag ("Music");
		audioBGM = MusicObject.GetComponents<AudioSource> ();
		audioBGM[0].volume = GameManager.instance.musicVolume;
		audioBGM[1].volume = GameManager.instance.musicVolume;

		try { // try to get sfxAudioSources and set Slider values as not all scenes have a player or the sliders 
			sfxAudioSources = player.GetComponents<AudioSource> ();

			foreach (AudioSource audio in sfxAudioSources) {
				audio.volume = GameManager.instance.sfxVolume;
			}

			musicSlider.value = GameManager.instance.musicVolume;
			sfxSlider.value = GameManager.instance.sfxVolume;

		} catch (System.Exception) {
			Debug.Log ("Slider or player not in scene"); 
		}
	}


	public void BGMSlider(float value) // method which is run when the BGM slider is moved
	{
		GameManager.instance.musicVolume = value; // sets the Game manager's background music volume to the sliders value using the float parameter
		audioBGM[0].volume = value; // sets the volume of the audio sources to the value of the slider
		audioBGM[1].volume = value;
	}

	public void SFXSlider(float value)
	{
		GameManager.instance.sfxVolume = value;
	}

	public void MuteBGM(){ // method to mute the BackGround Music when the mute background music toggle is checked

		GameManager.instance.isMuted = !GameManager.instance.isMuted; // GameManager.instance.isMuted now equal to the opersite

		if (GameManager.instance.isMuted == false) {
			GameManager.instance.isMuted = false;
			audioBGM[0].mute = !audioBGM[0].mute;
			audioBGM[1].mute = !audioBGM[1].mute;
			foreach (AudioSource audio in sfxAudioSources) {
				audio.mute = !audio.mute;
			}
		} else {
			GameManager.instance.isMuted = true;
			audioBGM[0].mute = !audioBGM[0].mute;
			audioBGM[1].mute = !audioBGM[1].mute;
			foreach (AudioSource audio in sfxAudioSources) {
				audio.mute = !audio.mute;
			}
		}
					
	}

	public void Small()
	{
		GameManager.instance.fontSize = "Small"; // subtitle button method sets the fontsize in the GameManager 
	}

	public void Medium()
	{
		GameManager.instance.fontSize = "Medium";
	}

	public void Large()
	{
		GameManager.instance.fontSize = "Large";
	}

	public void MainMenu()
	{
		GameManager.instance.BackToMenu ();
	}

	public void Exit()
	{
		Application.Quit (); // Exits the Game
	}

}

	



		

	
	