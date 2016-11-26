using UnityEngine;
using System.Collections;

public class CollisionBorder : MonoBehaviour {
	
	public GameObject toDestroy;
	public string tag;

	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.CompareTag (tag)) {
			Destroy (toDestroy);
			Debug.Log("GAME OVER");
		}

	}
}
