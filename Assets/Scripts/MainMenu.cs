using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public GameObject gameUI;
	public GameObject startMenu;
	public GameObject optionsResumePosition;
	public GameObject optionsPausePosition;

	public GameObject optionsMenuUI;
	public GameObject mainMenu;
	public GameObject creditsMenu;
	public GameObject pauseMenu;
	public GameObject backgroundStars;


	public void Start (){
		gameUI.SetActive (true); gameUI.transform.position = optionsPausePosition.transform.position;
		mainMenu.SetActive (true);
		backgroundStars.SetActive (true);

		optionsMenuUI.SetActive (false);
		creditsMenu.SetActive (false);
		pauseMenu.SetActive (false);

		Debug.Log ("Initial boot. The game has started");
	}

	public void PlayGame()
	{
		Debug.Log ("Starting game");
		startMenu.SetActive (false);
		gameUI.transform.position = optionsResumePosition.transform.position;
	}

	/*public void LoadSavedGame()
	{
		
	}*/


	public void QuitGame()
	{
		Debug.Log ("Closing the game...");
		Application.Quit ();
	}

}
