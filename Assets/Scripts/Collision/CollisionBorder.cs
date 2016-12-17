using UnityEngine;
using System.Collections;

public class CollisionBorder : MonoBehaviour {
	public string tag;
	public EventsManager eventsManager;

	void Awake(){
		if (!eventsManager) {
			eventsManager = GetComponentInParent<EventsManager> ();
		}
	}

	void OnTriggerEnter(Collider col) {
		if (col.gameObject.CompareTag (tag)) {
			Die ();
			Destroy (gameObject.transform.parent.gameObject);
			Debug.Log("GAME OVER");

		}

	}

	void Die(){
		eventsManager.Die ();
	}
}