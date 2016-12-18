using UnityEngine;
using System.Collections;

public class CollisionSpecialFood : MonoBehaviour {

	public EventsManager eventManager;
	public SpecialFoodManager specialFoodManager;
	public FoodSpawner foodSpawner;

	void OnTriggerEnter2D(Collider2D col) {
		if(col.gameObject.CompareTag("Player")){
			eventManager.Eat(); 
			//SpecialFoodManager specialFoodManager = col.gameObject.GetComponentInParent<SpecialFoodManager> ();
			specialFoodManager.Disable ();
			//FoodSpawner foodSpawner = col.gameObject.GetComponentInParent<FoodSpawner> ();
			if (foodSpawner) {
				foodSpawner.SpawnPowerUp ();
			}
		}
	}



}
