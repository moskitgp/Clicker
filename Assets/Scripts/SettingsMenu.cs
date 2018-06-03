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
	}

	public void ResetProgress(){
		PlayerPrefs.DeleteAll ();
		Debug.Log ("Progress has been erased.");
		LoadGame ();
	}
}
