using UnityEngine;
using System.Collections;

public class LogCollision : MonoBehaviour {

	void OnTriggerEnter(Collider col) {
		Debug.Log ("I collided with " + col.gameObject.name);
	}

}
