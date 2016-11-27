using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MusicManager : MonoBehaviour {
	
	public List<AudioClip> musics = new List<AudioClip>();
	public AudioSource audioSource;
	private AudioClip playing;

	public void OnStart(){
		SelectMusic ();
	}

	public void SelectMusic(){
		bool musicFind = false;
		AudioClip musicToPlay;
		while (!musicFind) {
			if (musics.Count == 1) {
				musicToPlay = musics [0];
			} else {
				musicToPlay = musics [Random.Range (0, musics.Count - 1)];
				if (musicToPlay != playing) {
					musicFind = true;
					playing = musicToPlay;
				}
			}
		}
	}

	public void PlayMusic(){
		audioSource.PlayOneShot (playing);
	}
}
