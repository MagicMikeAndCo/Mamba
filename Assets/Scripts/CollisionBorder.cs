using UnityEngine;
using System.Collections;

public class CollisionBorder : MonoBehaviour {
	public string tag;

	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.CompareTag (tag)) {
			Destroy (gameObject.transform.parent.gameObject);
			Debug.Log("GAME OVER");
		}

	}
}