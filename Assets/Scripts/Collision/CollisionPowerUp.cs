using UnityEngine;
using System.Collections;

public class CollisionPowerUp : MonoBehaviour {

	public GameObject prefab;
	public EventsManager eventManager;

	void OnTriggerEnter(Collider col) {
		if(!col.gameObject.CompareTag("Explosion")){
			eventManager.Eat();
			gameObject.SetActive (false);
		}

	}
}
