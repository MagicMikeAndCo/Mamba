using UnityEngine;
using System.Collections;

public class CollisionPowerUp : MonoBehaviour {

	public GameObject prefab;
	public EventsManager eventManager;

	void OnTriggerEnter2D(Collider2D col) {
		if(!col.gameObject.CompareTag("Explosion")){
			eventManager.Eat();
			gameObject.SetActive (false);
		}

	}
}
