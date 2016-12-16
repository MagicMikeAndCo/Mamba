using UnityEngine;
using System.Collections;

public class SoundManager : AbstractSingleton<SoundManager> {
	private AudioSource[] audios;

	public void Start(){
		audios = GetComponents<AudioSource> ();
	}
	
	public void PlaySound(AudioClip clip){
		if (!audios [0].isPlaying) {
			audios [0].clip = clip;
			audios [0].Play ();
		} else {
			audios [1].clip = clip;
			audios [1].time = 1f;
			audios [1].Play ();
		}
	}
	public override void Initialize (){}

}
