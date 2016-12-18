using UnityEngine;
using System.Collections;

public class DieCollision : MonoBehaviour {

	public EventsManager eventsManager;

	void Awake(){
		if (!eventsManager) {
			eventsManager = GetComponentInParent<EventsManager> ();
		}
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.CompareTag (gameObject.tag) || col.gameObject.CompareTag("Border") 
			|| col.gameObject.CompareTag ("Explosion")) {
			Die ();
			Destroy (gameObject.transform.parent.gameObject);
			//Debug.Log("GAME OVER");
		}
	}

	void Die(){
		eventsManager.Die ();
	}
}
