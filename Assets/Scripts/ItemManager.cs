using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour {

	public Text itemInfo;
	public Click click;
	public float cost;
	public float tickValue;
	public int count;
	public string itemName;
	public GameObject itemB;
	public int itemLevel = 0;
	public static float onionsSpendOnItems = 0f;

    private float baseCost;
    private float baseTickValue;
    private Transform text;
	private Transform image;

	public Text costText;
	private float costK;
	private float costM;
	private float costB;
	private float costT;

	void Start(){
        baseCost = cost;
        baseTickValue = tickValue;
        text = itemB.transform.Find ("Text");
		image = itemB.transform.Find ("Image");

		PlayerPrefs.SetInt (name + "_defaultlevel", itemLevel);
		PlayerPrefs.SetInt(name + "_defaultcount", count);
        PlayerPrefs.SetFloat(name + "_defaultcost", cost);
        PlayerPrefs.SetFloat(name + "_defaultTickValue", tickValue);
        PlayerPrefs.SetFloat ("defaultonionsSpendOnItems", onionsSpendOnItems);
	}

	public void Unlock() {
		//itemB.SetActive (true);     // old system of unlocking, very buggy
		itemB.GetComponent<Image>().enabled = true;
		itemB.GetComponent<Button>().enabled = true;
		text.gameObject.GetComponent<Text> ().enabled = true;
		image.gameObject.GetComponent<Image> ().enabled = true;
	}

	void Update (){

		if (cost < 1000f) {
			costText.text = cost.ToString ();
		}
		if (cost >= 1000f && cost < 1000000f) {
			costK = cost/1000f;
			costText.text = costK.ToString ("f2") + "K";
		}
		if (cost >= 1000000f && cost < 1000000000f) {
			costM = cost/1000000f;
			costText.text = costM.ToString ("f2") + "M";
		}
		if (cost >= 1000000000f && cost < 1000000000000f) {
			costB = cost/1000000000f;
			costText.text = costB.ToString ("f2") + "B";
		}
		if (cost >= 1000000000000f) {
			costT = cost/1000000000000f;
			costText.text = costT.ToString ("f2") + "T";
		}

		itemInfo.text = itemName + "\nLevel: " + itemLevel + "\nCost: " + costText.text + "\nOnions: " + tickValue + "/s";

		if (itemLevel >= 10) {
			Unlock ();		
		}

		if (itemLevel < 10) {
			//itemB.SetActive (false);	     // old system of unlocking, very buggy
			itemB.GetComponent<Image>().enabled = false;
			itemB.GetComponent<Button>().enabled = false;
			text.gameObject.GetComponent<Text> ().enabled = false;
			image.gameObject.GetComponent<Image> ().enabled = false;
		}

		if (Input.GetKeyDown (KeyCode.S)) {
			SaveGame();	}
		if (Input.GetKeyDown (KeyCode.L)) {	
			LoadGame();	}

		if (cost == 0) {
			DefaultItemManagerLevel();
		}

	//	Debug.Log (gameObject.name + ": " + PlayerPrefs.GetInt(name));

	}

	public void PurchasedItems(){
		if (click.onionsCount >= cost) {
			click.onionsCount -= +cost;
			onionsSpendOnItems += cost;

			count += 1;
			itemLevel += 1;
			cost = Mathf.Round (baseCost * Mathf.Pow (1.20f, count));
            tickValue = Mathf.Round(baseTickValue * Mathf.Pow(1.02f, count));

            Debug.Log (name + " upgraded to level " + itemLevel);

			if (itemLevel == 10) {
				AcceleratingStars.AccelerateStars();		
				Debug.Log (itemB.name + " was unlocked");
			}
		}
	}

	public void SaveGame(){
		PlayerPrefs.SetInt (name + "_level", itemLevel);
		PlayerPrefs.SetInt(name + "_count", count);
        PlayerPrefs.SetFloat(name + "_cost", cost);
        PlayerPrefs.SetFloat(name + "_tickValue", tickValue);
        PlayerPrefs.SetFloat ("onionsSpendOnItems", onionsSpendOnItems);
	}
	public void LoadGame(){        
		itemLevel = PlayerPrefs.GetInt (name + "_level");
		count = PlayerPrefs.GetInt(name + "_count");
        cost = PlayerPrefs.GetFloat(name + "_cost");
        tickValue = PlayerPrefs.GetFloat(name + "_tickValue");
        onionsSpendOnItems = PlayerPrefs.GetFloat ("onionsSpendOnItems");
	}

	public void DefaultItemManagerLevel(){
		itemLevel = PlayerPrefs.GetInt (name + "_defaultlevel");
		count = PlayerPrefs.GetInt(name + "_defaultcount");
        cost = PlayerPrefs.GetFloat(name + "_defaultcost");
        tickValue = PlayerPrefs.GetFloat(name + "_defaultTickValue");
        onionsSpendOnItems = PlayerPrefs.GetFloat ("defaultonionsSpendOnItems");
	}		
}