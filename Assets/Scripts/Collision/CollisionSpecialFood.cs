using UnityEngine;
using System.Collections;

public class CollisionSpecialFood : MonoBehaviour {

	public GameObject prefab;
	public EventsManager eventManager;

	void OnTriggerEnter(Collider col) {
		if(col.gameObject.CompareTag(prefab.tag)){
			eventManager.Eat(); 
			SpecialFoodManager specialFoodManager = col.gameObject.GetComponentInParent<SpecialFoodManager> ();
			specialFoodManager.Disable ();
			FoodSpawner foodSpawner = col.gameObject.GetComponentInParent<FoodSpawner> ();
			if (foodSpawner) {
				foodSpawner.SpawnPowerUp ();
			}
		}
	}



}
