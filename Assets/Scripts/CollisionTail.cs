using UnityEngine;
using System.Collections;

public class CollisionTail : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.CompareTag (gameObject.tag)) {
			Destroy (gameObject.transform.parent.gameObject);
			Debug.Log("GAME OVER");
		}
	}
}
