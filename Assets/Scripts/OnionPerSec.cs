using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnionPerSec : MonoBehaviour {

	public Text opsDisplay;
	public Click click;
	public ItemManager[] items;

	void Start (){
		StartCoroutine (AutoTick ());
	}

	void Update (){
		opsDisplay.text = GetOnionPerSec () + "\nOnions/Sec";

		/*if (Input.GetKeyDown (KeyCode.S)) {
			SaveGame();}
		if (Input.GetKeyDown (KeyCode.L)) {
			LoadGame();}*/
	}

	public float GetOnionPerSec(){
		float tick = 0;
		foreach (ItemManager item in items) {
			tick += item.count * item.tickValue;
		}
		return tick;
	}

	public void AutoOnionPerSec (){
		click.onionsCount += GetOnionPerSec () /60;
	}

	IEnumerator AutoTick(){
		while (true) {
			AutoOnionPerSec ();
			yield return new WaitForSeconds (1f/60);
		}
	}

	/*public void SaveGame(){
		PlayerPrefs.SetFloat ("AutoOnionPerSec", AutoOnionPerSec);
	}
	public void LoadGame(){			
		AutoOnionPerSec = PlayerPrefs.GetFloat ("AutoOnionPerSec");
	}*/
}
