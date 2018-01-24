using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {

	public AudioClip[] clips;
	private AudioSource audioSource;

	void Start () {

		audioSource = GetComponent<AudioSource> ();
		audioSource.loop = false;
		//audioSource.volume = 0.5f;
		
	}

	private AudioClip GetRandomClip(){
		return clips[Random.Range(0, 5)];
	}

	void Update () {
		if (audioSource.isPlaying) {
			audioSource.clip = GetRandomClip ();
			audioSource.Play ();
		}
	}
}
