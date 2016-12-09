using UnityEngine;
using System.Collections;

public class SpeedUpEatBehaviour : AbstractEatBehaviour {

	public override void Eat (GameObject eatObject)
	{
		SpeedManager manager = SpeedManager.GetInstance ();
		if (eatObject.tag == "SpecialFood" || eatObject.tag == "Food") {
			manager.addSpeed ();
		} else if (eatObject.tag == "SlowDownPowerUp") {
			manager.slowSpeed ();
		} else if (eatObject.tag == "SpeedUpPowerUp") {
			manager.superSpeed ();
		} else {
			Debug.Log ("Cas non pris en compte : " + eatObject.tag );
		}

	}


}
