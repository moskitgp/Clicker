using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

	public static bool GameIsPaused = false;

	public GameObject pauseMenuUI;

	public GameObject gameUI;

	
	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.Escape)) 
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
		Time.timeScale = 1f;
		GameIsPaused = false;	

		//gameUI.SetActive (true);
	}
	public void Pause(){
		pauseMenuUI.SetActive (true);
		Time.timeScale = 0f;
		GameIsPaused = true;

		//gameUI.SetActive (false);
	}

	public void LoadMenu()
	{
		Time.timeScale = 1f;
		SceneManager.LoadScene ("level0");
	}

	public void QuitGame()
	{
		Debug.Log ("Closing the game...");
		Application.Quit ();
	}
}
