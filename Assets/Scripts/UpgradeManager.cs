using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeManager : MonoBehaviour {

	public Click click;
	public Text itemInfo;
	public float cost;
	public int count = 0;
	public float clickMultiplier;
	public string itemName;
	public int upgradeLevel;
	public GameObject itemB;
	public static float onionsSpendOnUpgrades = 0f;

	private float _newCost;
    private float baseCost;
    private float baseClickMultiplier;
    private Transform text;
	private Transform image;
	public Text costText;
	private float costK;
	private float costM;
	private float costB;
	private float costT;


	//public GameObject upgrade1;

	void Start(){
		baseCost = cost;
        baseClickMultiplier = clickMultiplier;
		text = itemB.transform.Find ("Text");
		image = itemB.transform.Find ("Image");

		PlayerPrefs.SetInt (name + "_defaultlevel", upgradeLevel);
		PlayerPrefs.SetInt (name + "_defaultcount", count);
        PlayerPrefs.SetFloat (name + "_defaultcost", cost);
        PlayerPrefs.SetFloat (name + "_defaultClickMultiplier", clickMultiplier);
        PlayerPrefs.SetFloat ("defaultonionsSpendOnUpgrades", onionsSpendOnUpgrades);
	}

	public void Unlock() {
		//itemB.SetActive (true);     // old system of unlocking, very buggy
		itemB.GetComponent<Image>().enabled = true;
		itemB.GetComponent<Button>().enabled = true;
		text.gameObject.GetComponent<Text> ().enabled = true;
		//Debug.Log (itemB.name + " was unlocked");
		image.gameObject.GetComponent<Image> ().enabled = true;
	}

	void Update(){
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

		itemInfo.text = itemName + "\nLevel: " + upgradeLevel + "\nCost: " + costText.text + "\nMultiplier: " + clickMultiplier;				// how to display item/upgrade text on screen


		if (upgradeLevel >= 10) {
			Unlock ();
		}
		if (upgradeLevel < 10) {
			//itemB.SetActive (false);	     // old system of unlocking, very buggy
			itemB.GetComponent<Image>().enabled = false;
			itemB.GetComponent<Button>().enabled = false;
			text.gameObject.GetComponent<Text> ().enabled = false;
			image.gameObject.GetComponent<Image> ().enabled = false;
		}

		if (Input.GetKeyDown (KeyCode.S)) {
			SaveGame();	}						// saving game progress with 'S' key
		if (Input.GetKeyDown (KeyCode.L)) {
			LoadGame();	}						// loading game progress with 'L' key
		if (Input.GetKeyDown (KeyCode.X)) {
			PlayerPrefs.DeleteAll(); 
			Debug.Log ("Progress has been erased."); }			// deleting game progress with 'X' key

		if (cost == 0) {
			DefaultUpgradeManagerLevel();
		}

		//Debug.Log (gameObject.name + ": " + PlayerPrefs.GetInt(name));
	}

	public void PurchasedUpgrade(){
		if (click.onionsCount >= cost){
			click.onionsCount -= cost;
			onionsSpendOnUpgrades += cost;

			count += 1;
			upgradeLevel += 1;
			click.onionsPerClick += clickMultiplier;
			cost = Mathf.Round (baseCost * Mathf.Pow (1.20f, count));
            clickMultiplier = Mathf.Round (baseClickMultiplier * Mathf.Pow (1.015f, count));

            Debug.Log (name + " upgraded to level " + upgradeLevel);

			if (upgradeLevel == 10) {
				AcceleratingStars.AccelerateStars();		
				Debug.Log (itemB.name + " was unlocked");
			}
		}
	}

	public void SaveGame(){
		PlayerPrefs.SetInt (name + "_level", upgradeLevel);
		PlayerPrefs.SetInt (name + "_count", count);
        PlayerPrefs.SetFloat(name + "_cost", cost);
        PlayerPrefs.SetFloat(name + "_clickMultiplier", clickMultiplier);

        PlayerPrefs.SetFloat ("onionsSpendOnUpgrades", onionsSpendOnUpgrades);
	}
	public void LoadGame(){		
		upgradeLevel = PlayerPrefs.GetInt (name + "_level");
		count = PlayerPrefs.GetInt (name + "_count");
        cost = PlayerPrefs.GetFloat(name + "_cost");
        clickMultiplier = PlayerPrefs.GetFloat(name + "_clickMultiplier");

        onionsSpendOnUpgrades = PlayerPrefs.GetFloat ("onionsSpendOnUpgrades");
	}

	public void DefaultUpgradeManagerLevel(){
		upgradeLevel = PlayerPrefs.GetInt (name + "_defaultlevel");
		count = PlayerPrefs.GetInt (name + "_defaultcount");
        cost = PlayerPrefs.GetFloat(name + "_defaultcost");
        clickMultiplier = PlayerPrefs.GetFloat(name + "_defaultClickMultiplier");

        
        onionsSpendOnUpgrades = PlayerPrefs.GetFloat ("defaultonionsSpendOnUpgrades");
	}
}