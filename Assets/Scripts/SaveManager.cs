﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SaveManager : MonoBehaviour {	

	public GameObject upgradeManager1;
	public GameObject upgradeManager2;
	public GameObject upgradeManager3;
	public GameObject upgradeManager4;
	public GameObject upgradeManager5;
	public GameObject itemManager1;
	public GameObject itemManager2;
	public GameObject itemManager3;
	public GameObject itemManager4;
	public GameObject itemManager5;
	public GameObject click;
	public GameObject backgroundStars;

	private bool autosaveFeature;

	void Start()
	{
		StartCoroutine(autoSave());
	}

	public void SetAutosave(){
		autosaveFeature = !autosaveFeature;
		Debug.Log ("Autosave set to: " + autosaveFeature);
	}

	IEnumerator autoSave()
	{
		while(true) { 
			yield return new WaitForSeconds(100);
			if(autosaveFeature){
				SaveGame ();
				Debug.Log ("Autosave feature completed");
			}
		}
	}

	public void SaveGame (){
		upgradeManager1.GetComponent<UpgradeManager> ().SaveGame ();
		upgradeManager2.GetComponent<UpgradeManager> ().SaveGame ();
		upgradeManager3.GetComponent<UpgradeManager> ().SaveGame ();
		upgradeManager4.GetComponent<UpgradeManager> ().SaveGame ();
		upgradeManager5.GetComponent<UpgradeManager> ().SaveGame ();

		itemManager1.GetComponent<ItemManager> ().SaveGame ();
		itemManager2.GetComponent<ItemManager> ().SaveGame ();
		itemManager3.GetComponent<ItemManager> ().SaveGame ();
		itemManager4.GetComponent<ItemManager> ().SaveGame ();
		itemManager5.GetComponent<ItemManager> ().SaveGame ();

		click.GetComponent<Click> ().SaveGame ();

		backgroundStars.GetComponent<AcceleratingStars> ().SaveGame ();
	}

	public void LoadGame (){
		upgradeManager1.GetComponent<UpgradeManager> ().LoadGame ();
		upgradeManager2.GetComponent<UpgradeManager> ().LoadGame ();
		upgradeManager3.GetComponent<UpgradeManager> ().LoadGame ();
		upgradeManager4.GetComponent<UpgradeManager> ().LoadGame ();
		upgradeManager5.GetComponent<UpgradeManager> ().LoadGame ();

		itemManager1.GetComponent<ItemManager> ().LoadGame ();
		itemManager2.GetComponent<ItemManager> ().LoadGame ();
		itemManager3.GetComponent<ItemManager> ().LoadGame ();
		itemManager4.GetComponent<ItemManager> ().LoadGame ();
		itemManager5.GetComponent<ItemManager> ().LoadGame ();

		click.GetComponent<Click> ().LoadGame ();

		backgroundStars.GetComponent<AcceleratingStars> ().LoadGame ();
	}


}
