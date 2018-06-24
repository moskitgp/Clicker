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
		opsDisplay.text = "Onions/Sec\n" + GetOnionPerSec ();
	}

	public float GetOnionPerSec(){
		float tick = 0;
		foreach (ItemManager item in items) {
			tick += item.count * item.tickValue;
		}
		return tick;
	}

	public void AutoOnionPerSec (){
		click.onionsCount += GetOnionPerSec () /5;
	}

	IEnumerator AutoTick(){
		while (true) {
			AutoOnionPerSec ();
			yield return new WaitForSeconds (1f/5);
		}
	}
}
