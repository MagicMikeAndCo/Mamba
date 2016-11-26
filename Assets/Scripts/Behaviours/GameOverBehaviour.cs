using UnityEngine;
using System.Collections;

public class GameOverBehaviour : AbstractDieBehaviour {

	public GameObject gameOverPanel;

	public override void Die(GameObject deadObject){
		Debug.Log (gameOverPanel);
		if (gameOverPanel) {
			gameOverPanel.SetActive (true);
		}
	}
}
