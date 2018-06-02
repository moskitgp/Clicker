using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public GameObject gameUI;
	public GameObject startMenu;
	public GameObject optionsResumePosition;
	public GameObject optionsPausePosition;


	public void Awake (){
		gameUI.SetActive (true);
		gameUI.transform.position = optionsPausePosition.transform.position;
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
