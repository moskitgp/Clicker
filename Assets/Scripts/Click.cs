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
		onionDisplay.text = "Cebule: " + onionsCount.ToString("F0"); // 
		OPC.text = onionsPerClick + " ceb/klik";

		onionsSpendInTotal = ItemManager.onionsSpendOnItems + UpgradeManager.onionsSpendOnUpgrades; //
		onionsSpendInTotalText.text = "Wydane Cebule\n" + onionsSpendInTotal.ToString();

		if (Input.GetKeyDown (KeyCode.ScrollLock)) {
			onionsPerClick += 100f; // debug cheat adding 100 onions/click
		}
	}

	public void Clicked (){		
		onionsCount += onionsPerClick; // what happens when user clicks
	}
}
