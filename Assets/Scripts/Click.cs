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
	private float onionsSpendInTotalK;
	private float onionsSpendInTotalM;
	private float onionsSpendInTotalB;
	private float onionsSpendInTotalT;
	public Text onionsSpendInTotalText;

	private float onionsPerClickK;
	private float onionsPerClickM;
	private float onionsPerClickB;
	private float onionsPerClickT;

	private float onionsCountK;
	private float onionsCountM;
	private float onionsCountB;
	private float onionsCountT;

	void Start(){
	}

	void Update(){
		

		onionsSpendInTotal = ItemManager.onionsSpendOnItems + UpgradeManager.onionsSpendOnUpgrades; 

		///////////////////////////////////////////////////////////////////////////////////////////////////
		if (onionsCount < 1000f) {
			onionDisplay.text = "Space Onions\n" + onionsCount.ToString ("f0");
		}
		if (onionsCount >= 1000f && onionsCount < 1000000f) {
			onionsCountT = onionsCount/1000f;
			onionDisplay.text = "Space Onions\n" + onionsCountT.ToString ("f3") + "K";
		}
		if (onionsCount >= 1000000f && onionsCount < 1000000000f) {
			onionsCountM = onionsCount/1000000f;
			onionDisplay.text = "Space Onions\n" + onionsCountM.ToString ("f3") + "M";
		}
		if (onionsCount >= 1000000000f && onionsCount < 1000000000000f) {
			onionsCountB = onionsCount/1000000000f;
			onionDisplay.text = "Space Onions\n" + onionsCountB.ToString ("f3") + "B";
		}
		if (onionsCount >= 1000000000000f) {
			onionsCountT = onionsCount/1000000000000f;
			onionDisplay.text = "Space Onions\n" + onionsCountT.ToString ("f3") + "T";
		}
		///////////////////////////////////////////////////////////////////////////////////////////////////
		if (onionsPerClick < 1000f) {
			OPC.text = onionsPerClick.ToString () + "\nOnions/Click";
		}
		if (onionsPerClick >= 1000f && onionsPerClick < 1000000f) {
			onionsPerClickK = onionsPerClick/1000f;
			OPC.text = onionsPerClickK.ToString ("f2") + "K" + "\nOnions/Click";
		}
		if (onionsPerClick >= 1000000f && onionsPerClick < 1000000000f) {
			onionsPerClickM = onionsPerClick/1000000f;
			OPC.text = onionsPerClickM.ToString ("f2") + "M" + "\nOnions/Click";
		}
		if (onionsPerClick >= 1000000000f && onionsPerClick < 1000000000000f) {
			onionsPerClickB = onionsPerClick/1000000000f;
			OPC.text = onionsPerClickB.ToString ("f2") + "B" + "\nOnions/Click";
		}
		if (onionsPerClick >= 1000000000000f) {
			onionsPerClickT = onionsPerClick/1000000000000f;
			OPC.text = onionsPerClickT.ToString ("f2") + "T" + "\nOnions/Click";
		}
		///////////////////////////////////////////////////////////////////////////////////////////////////
		if (onionsSpendInTotal < 1000f) {
			onionsSpendInTotalText.text = onionsSpendInTotal.ToString () + "\nOnions Spent";
		}
		if (onionsSpendInTotal >= 1000f && onionsSpendInTotal < 1000000f) {
			onionsSpendInTotalK = onionsSpendInTotal/1000f;
			onionsSpendInTotalText.text = onionsSpendInTotalK.ToString ("f2") + "K" + "\nOnions Spent";
		}
		if (onionsSpendInTotal >= 1000000f && onionsSpendInTotal < 1000000000f) {
			onionsSpendInTotalM = onionsSpendInTotal/1000000f;
			onionsSpendInTotalText.text = onionsSpendInTotalM.ToString ("f2") + "M" + "\nOnions Spent";
		}
		if (onionsSpendInTotal >= 1000000000f && onionsSpendInTotal < 1000000000000f) {
			onionsSpendInTotalB = onionsSpendInTotal/1000000000f;
			onionsSpendInTotalText.text = onionsSpendInTotalB.ToString ("f2") + "B" + "\nOnions Spent";
		}
		if (onionsSpendInTotal >= 1000000000000f) {
			onionsSpendInTotalT = onionsSpendInTotal/1000000000000f;
			onionsSpendInTotalText.text = onionsSpendInTotalT.ToString ("f2") + "T" + "\nOnions Spent";
		}
		///////////////////////////////////////////////////////////////////////////////////////////////////


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
		Debug.Log ("Click, "+ "Onions: " + onionsCount);
	}

	public void CheatClick (){
		onionsPerClick += 1000000000f; // debug cheat adding 100 onions/click
		Debug.Log ("CheatClick");
	}

	public void SaveGame(){
		PlayerPrefs.SetFloat ("onionsPerClick", onionsPerClick);
		PlayerPrefs.SetFloat ("onionsCount", onionsCount);
		Debug.Log ("Game progress saved");
	}
	public void LoadGame(){			
		onionsPerClick = PlayerPrefs.GetFloat ("onionsPerClick");
		onionsCount = PlayerPrefs.GetFloat ("onionsCount");
		Debug.Log ("Game progress loaded");
		if (onionsPerClick == 0) {
			onionsPerClick = 1;
		}
	}
}
