using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SaveManager : MonoBehaviour {

	public GameObject upgrade1, upgrade2, upgrade3, upgrade4, upgrade5;

	int upgradeLevel1, upgradeLevel2, upgradeLevel3, upgradeLevel4, upgradeLevel5;
	/*
	void Start(){
		upgradeLevel1 = upgrade1.GetComponent<UpgradeManager>().upgradeLevel;
		upgradeLevel2 = upgrade2.GetComponent<UpgradeManager>().upgradeLevel;
		upgradeLevel3 = upgrade3.GetComponent<UpgradeManager>().upgradeLevel;
		upgradeLevel4 = upgrade4.GetComponent<UpgradeManager>().upgradeLevel;
		upgradeLevel5 = upgrade5.GetComponent<UpgradeManager>().upgradeLevel;
	}

	void Update(){
		//if (upgradeLevel1 > 0 || upgradeLevel2 > 0 || upgradeLevel3 > 0 || upgradeLevel4 > 0 || upgradeLevel5 > 0)
			//SaveGame ();

		//	Debug.Log (upgradeLevel1);
	}

	public void SaveGame(){
		PlayerPrefs.SetInt ("upgrade1Level", upgradeLevel1);		
		PlayerPrefs.SetInt ("upgrade2Level", upgradeLevel2);		
		PlayerPrefs.SetInt ("upgrade3Level", upgradeLevel3);		
		PlayerPrefs.SetInt ("upgrade4Level", upgradeLevel4);		
		PlayerPrefs.SetInt ("upgrade5Level", upgradeLevel5);
		Debug.Log (upgradeLevel1);
	}
	public void LoadGame(){
		PlayerPrefs.GetInt ("upgrade1Level");		
		PlayerPrefs.GetInt ("upgrade2Level");		
		PlayerPrefs.GetInt ("upgrade3Level");		
		PlayerPrefs.GetInt ("upgrade4Level");		
		PlayerPrefs.GetInt ("upgrade5Level");		
	}

*/
}
