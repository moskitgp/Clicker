using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeManager : MonoBehaviour {

	public Click click;
	public Text itemInfo;
	public float cost;
	public int count = 0;
	public int clickMultiplier;
	public string itemName;
	public int upgradeLevel;
	public GameObject itemB;
	public static float onionsSpendOnUpgrades = 0f;
	private float _newCost;
	private float baseCost;

	//public GameObject upgrade1;

	void Start(){
		baseCost = cost;
	}

	public void Unlock() {
		itemB.SetActive (true);
	}

	void Update(){
		itemInfo.text = itemName + "\nLevel: " + upgradeLevel + "\nCost: " + cost + "\nMultiplier: " + clickMultiplier;
		if (upgradeLevel >= 10) {
			Unlock ();		
		}

		if (Input.GetKeyDown (KeyCode.S)) {
			SaveGame();	}
		if (Input.GetKeyDown (KeyCode.L)) {
			LoadGame();	}


		//Debug.Log (gameObject.name + ": " + PlayerPrefs.GetInt(name));
	}

	public void PurchasedUpgrade(){
		if (click.onionsCount >= cost){
			click.onionsCount -= cost;
			onionsSpendOnUpgrades += cost;

			count += 1;
			upgradeLevel += 1;
			click.onionsPerClick += clickMultiplier;
			cost = Mathf.Round (baseCost * Mathf.Pow (1.15f, count));
		}
	}

	public void SaveGame(){
		PlayerPrefs.SetInt (name, upgradeLevel);
		PlayerPrefs.SetFloat ("onionsSpendOnUpgrades", onionsSpendOnUpgrades);
	}
	public void LoadGame(){		
		upgradeLevel = PlayerPrefs.GetInt (name);
		onionsSpendOnUpgrades = PlayerPrefs.GetFloat ("onionsSpendOnUpgrades");
	}
}
