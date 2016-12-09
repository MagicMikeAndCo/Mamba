using UnityEngine;
using System.Collections;

public class ScoreEatBehaviour : AbstractEatBehaviour {

	public int score;
	public TimerProgressionBar timer;

	#region implemented abstract members of AbstractDieBehaviour
	public override void Eat (GameObject eatObject)
	{
		int realScore = score;
		if (eatObject.tag == "SpecialFood") {
			realScore -= timer.getTime();
		}

		ScoreManager.GetInstance ().AddScore (realScore);
	}
	#endregion
}
