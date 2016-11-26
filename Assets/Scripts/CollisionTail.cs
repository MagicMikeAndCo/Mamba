using UnityEngine;
using System.Collections;

public class CollisionTail : MonoBehaviour {

	public GameObject toDestroy;

	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.CompareTag (gameObject.tag)) {
			Destroy (toDestroy);
			Debug.Log("GAME OVER");
		}
	}
}
