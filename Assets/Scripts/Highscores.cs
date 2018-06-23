using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highscores : MonoBehaviour {

	const string privateCode = "eBw3mgF2oUutTfOP0d81Sw2TwBjWMjVUa_y9BZ1Y1fGQ";
	const string publicCode = "5aaea520012b2e1068a10cb2";
	const string webURL = "http://dreamlo.com/lb/";

	/*public Highscore [] highscoresList;

	void Awake (){
		AddNewHighscore ("Michal", 50);
		AddNewHighscore ("Bartek", 25);
		AddNewHighscore ("Pamela", 45);

		DownloadHighcores ();	
	}


	public void AddNewHighscore (string username, int score){
		StartCoroutine (UploadNewHighscore (username, score));
	}


	IEnumerator UploadNewHighscore (string username, int score){
		WWW www = new WWW (webURL + privateCode + "/add/" + WWW.EscapeURL (username) + "/" + score);
		yield return www;

		if (string.IsNullOrEmpty (www.error))
			print ("Upload successful");
		else {
			print ("Error uploading: " + www.error);
		}
	}

	public void DownloadHighcores(){
		StartCoroutine ("DownloadHighscoreFromDatabase");

	}

	IEnumerator DownloadHighscoreFromDatabase (){
		WWW www = new WWW (webURL + publicCode + "/pipe/");
		yield return www;

		if (string.IsNullOrEmpty (www.error))
			FormatHighscores (www.text);
		else {
			print ("Error downloading: " + www.error);
		}
	}

	void FormatHighscores (string textStream){
		string[] entries = textStream.Split (new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries);
		highscoresList = new Highscore[entries.Length];

		for (int i = 0; i < entries.Length; i++) {
			string[] entryInfo = entries [i].Split (new char[] { '|' });
			string username = entryInfo [0];
			int score = int.Parse (entryInfo [1]);
			highscoresList [i] = new Highscore (username, score);
			print (highscoresList [i].username + ": " + highscoresList [i].score);
		}
	}

}

public struct Highscore{
	public string username;
	public int score;

	public Highscore(string _username, int _score){
		username = _username;
		score = _score;
	}*/
}