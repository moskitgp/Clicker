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
		onionDisplay.text = "Onions\n" + onionsCount.ToString("F0"); // 
		OPC.text = onionsPerClick + "\nOnions/Click";

		onionsSpendInTotal = ItemManager.onionsSpendOnItems + UpgradeManager.onionsSpendOnUpgrades; //
		onionsSpendInTotalText.text =  onionsSpendInTotal.ToString() + "\nOnions Spent";

		if (Input.GetKeyDown (KeyCode.ScrollLock)) {
			CheatClick (); // debug cheat adding 100 onions/click
		}
	}

	public void Clicked (){		
		onionsCount += onionsPerClick; // what happens when user clicks
	}

	public void CheatClick (){
		onionsPerClick += 10000f; // debug cheat adding 100 onions/click
	}
}
