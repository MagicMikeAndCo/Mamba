using UnityEngine;
using System.Collections;

public class CollisionFood : MonoBehaviour {

	public EventsManager eventManager;
	public TailManager tailManager;
	public FoodSpawner foodSpawner;
	public SpecialFoodManager specialFoodManager;

	void OnTriggerEnter2D(Collider2D col) {
		if(col.gameObject.CompareTag("Player")){
			//FoodSpawner foodSpawner = col.gameObject.GetComponentInParent<FoodSpawner> ();
			if (foodSpawner) {
				foodSpawner.Spawn();
			}
			//TailManager tailManager = gameObject.GetComponentInParent<TailManager> ();
			tailManager.AddList ();
			//SpecialFoodManager specialFoodManager = col.gameObject.GetComponentInParent<SpecialFoodManager> ();
			specialFoodManager.IncrementEatenFood ();
			eventManager.Eat(); 
		}
	
	}

}
