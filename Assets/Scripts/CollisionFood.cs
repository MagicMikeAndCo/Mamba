using UnityEngine;
using System.Collections;

public class CollisionFood : MonoBehaviour {

	public GameObject prefab;
	public EventsManager eventManager;

	void OnTriggerEnter2D(Collider2D col) {
		if(col.gameObject.CompareTag(prefab.tag)){
			FoodSpawner foodSpawner = col.gameObject.GetComponentInParent<FoodSpawner> ();
			if (foodSpawner) {
				foodSpawner.Spawn();
			}
			TailManager tailManager = gameObject.GetComponentInParent<TailManager> ();
			tailManager.AddList ();
			SpecialFoodManager specialFoodManager = col.gameObject.GetComponentInParent<SpecialFoodManager> ();
			specialFoodManager.IncrementEatenFood ();
			eventManager.Eat(); 
		}
	
	}

}
