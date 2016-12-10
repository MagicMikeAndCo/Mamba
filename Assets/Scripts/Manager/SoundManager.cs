using UnityEngine;
using System.Collections;

public class SoundManager : AbstractSingleton<SoundManager> {
	
	public void PlaySound(AudioClip clip){
		AudioSource audio = GetComponent<AudioSource> ();
		audio.clip = clip;
		audio.time = 1f;
		audio.Play ();
	}
	public override void Initialize (){}

}
