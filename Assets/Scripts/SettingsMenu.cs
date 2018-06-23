using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour {

	public AudioMixer audioMixer;
	public Dropdown resolutionDropdown;

	Resolution[] resolutions;

	public GameObject upgradeManager1;
	public GameObject upgradeManager2;
	public GameObject upgradeManager3;
	public GameObject upgradeManager4;
	public GameObject upgradeManager5;
	public GameObject itemManager1;
	public GameObject itemManager2;
	public GameObject itemManager3;
	public GameObject itemManager4;
	public GameObject itemManager5;
	public GameObject click;
	public GameObject backgroundStars;

	void Start()
	{
		resolutions = Screen.resolutions;
		resolutionDropdown.ClearOptions ();

		List<string> options = new List<string>();

		int currentResolutionIndex = 0;

		for (int i = 0; i <resolutions.Length; i++)
		{
			string option = resolutions[i].width + " x " +  resolutions[i].height;
			options.Add(option);

			if (resolutions [i].width == Screen.currentResolution.width && resolutions [i].height == Screen.currentResolution.height) 
			{
				currentResolutionIndex = i;
			}
		}
		resolutionDropdown.AddOptions (options);
		resolutionDropdown.value = currentResolutionIndex;
		resolutionDropdown.RefreshShownValue ();
	}

	public void SetResolution (int resolutionIndex)
	{
		Resolution resolution = resolutions [resolutionIndex];
		Screen.SetResolution (resolution.width, resolution.height, Screen.fullScreen);
		Debug.Log ("Resolution: " + resolution.width + "x" + resolution.height);
	}

	public void SetVolume(float volume)
	{
		audioMixer.SetFloat("volume", volume);
		Debug.Log (volume);
	}

	public void SetQuality(int qualityIndex)
	{
		QualitySettings.SetQualityLevel (qualityIndex);
		Debug.Log ("Quality level: " + qualityIndex);
	}

	public void SetFullscreen(bool isFullscreen)
	{
		Screen.fullScreen = isFullscreen;
		Debug.Log ("Fullscreen: " + isFullscreen);
	}

	public void LoadGame (){
		upgradeManager1.GetComponent<UpgradeManager> ().LoadGame ();
		upgradeManager2.GetComponent<UpgradeManager> ().LoadGame ();
		upgradeManager3.GetComponent<UpgradeManager> ().LoadGame ();
		upgradeManager4.GetComponent<UpgradeManager> ().LoadGame ();
		upgradeManager5.GetComponent<UpgradeManager> ().LoadGame ();

		itemManager1.GetComponent<ItemManager> ().LoadGame ();
		itemManager2.GetComponent<ItemManager> ().LoadGame ();
		itemManager3.GetComponent<ItemManager> ().LoadGame ();
		itemManager4.GetComponent<ItemManager> ().LoadGame ();
		itemManager5.GetComponent<ItemManager> ().LoadGame ();

		click.GetComponent<Click> ().LoadGame ();

		backgroundStars.GetComponent<AcceleratingStars> ().LoadGame ();
	}

	public void ResetProgress(){
		//PlayerPrefs.DeleteAll ();

		PlayerPrefs.DeleteKey ("Upgrade1_level");		
		PlayerPrefs.DeleteKey ("Upgrade2_level");		
		PlayerPrefs.DeleteKey ("Upgrade3_level");		
		PlayerPrefs.DeleteKey ("Upgrade4_level");		
		PlayerPrefs.DeleteKey ("Upgrade5_level");
		PlayerPrefs.DeleteKey ("Upgrade1_count");		
		PlayerPrefs.DeleteKey ("Upgrade2_count");		
		PlayerPrefs.DeleteKey ("Upgrade3_count");		
		PlayerPrefs.DeleteKey ("Upgrade4_count");		
		PlayerPrefs.DeleteKey ("Upgrade5_count");
		PlayerPrefs.DeleteKey ("Upgrade1_cost");		
		PlayerPrefs.DeleteKey ("Upgrade2_cost");		
		PlayerPrefs.DeleteKey ("Upgrade3_cost");		
		PlayerPrefs.DeleteKey ("Upgrade4_cost");		
		PlayerPrefs.DeleteKey ("Upgrade5_cost");
		PlayerPrefs.DeleteKey ("Worker1_level");		
		PlayerPrefs.DeleteKey ("Worker2_level");		
		PlayerPrefs.DeleteKey ("Worker3_level");		
		PlayerPrefs.DeleteKey ("Worker4_level");		
		PlayerPrefs.DeleteKey ("Worker5_level");
		PlayerPrefs.DeleteKey ("Worker1_count");		
		PlayerPrefs.DeleteKey ("Worker2_count");		
		PlayerPrefs.DeleteKey ("Worker3_count");		
		PlayerPrefs.DeleteKey ("Worker4_count");		
		PlayerPrefs.DeleteKey ("Worker5_count");
		PlayerPrefs.DeleteKey ("Worker1_cost");		
		PlayerPrefs.DeleteKey ("Worker2_cost");		
		PlayerPrefs.DeleteKey ("Worker3_cost");		
		PlayerPrefs.DeleteKey ("Worker4_cost");		
		PlayerPrefs.DeleteKey ("Worker5_cost");
		PlayerPrefs.DeleteKey ("onionsPerClick");
		PlayerPrefs.DeleteKey ("onionsCount");
		PlayerPrefs.DeleteKey ("BackgroundStars_mainSlow");
		PlayerPrefs.DeleteKey ("BackgroundStars_mainFast");

		upgradeManager1.GetComponent<UpgradeManager> ().DefaultUpgradeManagerLevel ();
		upgradeManager2.GetComponent<UpgradeManager> ().DefaultUpgradeManagerLevel ();
		upgradeManager3.GetComponent<UpgradeManager> ().DefaultUpgradeManagerLevel ();
		upgradeManager4.GetComponent<UpgradeManager> ().DefaultUpgradeManagerLevel ();
		upgradeManager5.GetComponent<UpgradeManager> ().DefaultUpgradeManagerLevel ();

		itemManager1.GetComponent<ItemManager> ().DefaultItemManagerLevel ();
		itemManager2.GetComponent<ItemManager> ().DefaultItemManagerLevel ();
		itemManager3.GetComponent<ItemManager> ().DefaultItemManagerLevel ();
		itemManager4.GetComponent<ItemManager> ().DefaultItemManagerLevel ();
		itemManager5.GetComponent<ItemManager> ().DefaultItemManagerLevel ();

		backgroundStars.GetComponent<AcceleratingStars> ().DefaultStarsSpeed ();



		Debug.Log ("Progress has been erased.");
	}
}
