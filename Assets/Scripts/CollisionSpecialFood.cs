using UnityEngine;
using System.Collections;

public class CollisionSpecialFood : MonoBehaviour {

	public GameObject prefab;
	public EventsManager eventManager;

	void OnTriggerEnter2D(Collider2D col) {
		if(col.gameObject.CompareTag(prefab.tag)){
			eventManager.Eat(); 
			SpecialFoodManager specialFoodManager = col.gameObject.GetComponentInParent<SpecialFoodManager> ();
			specialFoodManager.Disable ();
		}
	}



}
