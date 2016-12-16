using UnityEngine;
using System.Collections;

public class SoundManager : AbstractSingleton<SoundManager> {
	private AudioSource[] audios;

	public void Start(){
		audios = GetComponents<AudioSource> ();
	}
	
	public void PlaySound(AudioClip clip, float volume){
		if (!audios [0].isPlaying) {
			audios [0].clip = clip;
			audios [0].volume = volume;
			audios [0].Play ();
		} else {
			audios [1].clip = clip;
			audios [1].volume = volume;
			audios [1].Play ();
		}
	}
	public override void Initialize (){}

}
