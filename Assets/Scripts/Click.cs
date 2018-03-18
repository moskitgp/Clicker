using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Click : MonoBehaviour {

	public Text onionDisplay;
	public float onionsCount = 0f;
	public float onionsPerClick = 1f;
	public Text OPC;
	private float onionsSpendInTotal;
	public Text onionsSpendInTotalText;

	void Start(){
	}

	void Update(){
		
		onionDisplay.text = "Onions\n" + onionsCount.ToString("F0"); 
		OPC.text = onionsPerClick + "\nOnions/Click";

		onionsSpendInTotal = ItemManager.onionsSpendOnItems + UpgradeManager.onionsSpendOnUpgrades; 
		onionsSpendInTotalText.text = onionsSpendInTotal.ToString() + "\nOnions Spent";

		if (Input.GetKeyDown (KeyCode.ScrollLock)) {
			CheatClick (); // debug cheat adding 100 onions/click
			Debug.Log ("CheatKey");
		}

		if (Input.GetKeyDown (KeyCode.S)) {
			SaveGame();}
		if (Input.GetKeyDown (KeyCode.L)) {
 			LoadGame();}
	}

	public void Clicked (){		
		onionsCount += onionsPerClick; // what happens when user clicks
		Debug.Log ("Click");
	}

	public void CheatClick (){
		onionsPerClick += 10000f; // debug cheat adding 100 onions/click
		Debug.Log ("CheatClick");
	}

	public void SaveGame(){
		PlayerPrefs.SetFloat ("onionsPerClick", onionsPerClick);
		Debug.Log ("Save");
	}
	public void LoadGame(){			
		onionsPerClick = PlayerPrefs.GetFloat ("onionsPerClick");
		Debug.Log ("Load");
	}
}
