using UnityEngine;
using System.Collections;

public class CollisionPowerUp : MonoBehaviour {

	public GameObject prefab;
	public EventsManager eventManager;

	void OnTriggerEnter2D(Collider2D col) {
		eventManager.Eat(); 
	}
}
