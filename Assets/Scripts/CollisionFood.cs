using UnityEngine;
using System.Collections;

public class CollisionFood : MonoBehaviour {

	public GameObject prefab;

	void OnTriggerEnter2D(Collider2D col) {
		if(col.gameObject.CompareTag(prefab.tag)){
			FoodSpawner foodSpawner = col.gameObject.GetComponentInParent<FoodSpawner> ();
			if (foodSpawner) {
				col.gameObject.transform.position = foodSpawner.GetRandomPositionInZone ();
			}
			TailManager tailManager = gameObject.GetComponentInParent<TailManager> ();
			tailManager.AddList ();
		}
	
	}

}
