using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour {

	public Text itemInfo;
	public Click click;
	public float cost;
	public int tickValue;
	public int count;
	public string itemName;
	public GameObject itemB;
	public int itemLevel = 0;
	private float baseCost;
	public static float onionsSpendOnItems = 0f;



	void Start(){
		baseCost = cost;
	}

	public void Unlock() {
		itemB.SetActive (true);
	}

	void Update (){
		itemInfo.text = itemName + "\nLevel: " + itemLevel + "\nCost: " + cost + "\nOnions: " + tickValue + "/s";
		if (itemLevel >= 10) {
			Unlock ();		
		}
	}

	public void PurchasedItems(){
		if (click.onionsCount >= cost) {
			click.onionsCount -= +cost;
			onionsSpendOnItems += cost;

			count += 1;
			itemLevel += 1;
			cost = Mathf.Round (baseCost * Mathf.Pow (1.15f, count));
		}
	}
}
