using UnityEngine;
using System.Collections;

public class PlaySoundEatBehaviour : AbstractEatBehaviour {

	public AudioClip clip;

	#region implemented abstract members of AbstractDieBehaviour
	public override void Eat (GameObject eatObject)
	{
		SoundManager.GetInstance ().PlaySound (clip);
	}
	#endregion
}
