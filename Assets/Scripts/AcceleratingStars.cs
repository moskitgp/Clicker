using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcceleratingStars : MonoBehaviour {

	public GameObject slowStars;
	public GameObject fastStars;

	public static ParticleSystem slowStarsPS;
	public static ParticleSystem fastStarsPS;
	public static ParticleSystem.MainModule mainSlow;
	public static ParticleSystem.MainModule mainFast;

	void Start () {
		slowStarsPS = slowStars.GetComponent<ParticleSystem> ();
		mainSlow = slowStarsPS.main;

		fastStarsPS = fastStars.GetComponent<ParticleSystem> ();
		mainFast = fastStarsPS.main;

		mainSlow.startLifetimeMultiplier = 40f;
		mainSlow.startSpeedMultiplier = 0.5f;

		mainFast.startLifetimeMultiplier = 10;
		mainFast.startSpeedMultiplier = 2.5f;	

		PlayerPrefs.SetFloat (name + "_defaultmainSlow", mainSlow.simulationSpeed);
		PlayerPrefs.SetFloat (name + "_defaultmainFast", mainFast.simulationSpeed);

	}

	void Update(){
		if (mainFast.simulationSpeed < 1f) {
			mainFast.simulationSpeed = 1f;
		}if (mainSlow.simulationSpeed < 1f) {
			mainSlow.simulationSpeed = 1f;
		}
	}
	
	public static void AccelerateStars(){
		mainSlow.simulationSpeed *= 1.1f;
		mainFast.simulationSpeed *= 1.1f;
	}

	public void SaveGame(){
		PlayerPrefs.SetFloat (name + "_mainSlow", mainSlow.simulationSpeed);
		PlayerPrefs.SetFloat (name + "_mainFast", mainFast.simulationSpeed);
	}

	public void LoadGame(){
		mainSlow.simulationSpeed = PlayerPrefs.GetFloat (name + "_mainSlow");
		mainFast.simulationSpeed = PlayerPrefs.GetFloat (name + "_mainFast");
	}

	public void DefaultStarsSpeed(){
		mainSlow.simulationSpeed = PlayerPrefs.GetFloat (name + "_defaultmainSlow");
		mainFast.simulationSpeed = PlayerPrefs.GetFloat (name + "_defaultmainFast");
	}

}
