using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

	public static bool GameIsPaused = false;
	public GameObject pauseMenuUI;
	public GameObject optionsMenuUI;
	public GameObject gameUI;
	public GameObject mainMenu;
	public GameObject creditsMenu;

	public GameObject optionsPausePosition;
	public GameObject optionsResumePosition;
	
	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.Escape) && !mainMenu.activeInHierarchy && !creditsMenu.activeInHierarchy && !optionsMenuUI.activeInHierarchy) 
		{			
			if (GameIsPaused) 
			{
				Resume ();
			}else{
				Pause ();			
			}
		}
	}
	public void Resume(){
		pauseMenuUI.SetActive (false);
		//Time.timeScale = 1f;
		GameIsPaused = false;	
		gameUI.transform.position = optionsResumePosition.transform.position;
		Debug.Log ("Game Pause: " + GameIsPaused + "\nGame resumed.");
	}
	public void Pause(){		
		pauseMenuUI.SetActive (true);
		//Time.timeScale = 0f;
		GameIsPaused = true;
		gameUI.transform.position = optionsPausePosition.transform.position;
		Debug.Log ("Game Pause: " + GameIsPaused + "\nGame paused.");
	}

	/*public void LoadMenu()
	{
		Time.timeScale = 1f;
		SceneManager.LoadScene ("level0");
	}*/

	public void BackToMainMenu(){
		//Time.timeScale = 1f;
		GameIsPaused = false;	
		Debug.Log ("Game Pause: " + GameIsPaused + "\nGoing back to Main Menu");
		gameUI.transform.position = optionsPausePosition.transform.position;
	}

	public void QuitGame()
	{
		Debug.Log ("Closing the game...");
		Application.Quit ();
	}
}
