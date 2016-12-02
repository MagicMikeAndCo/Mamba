using UnityEngine;
using System.Collections;

public class CollisionSpecialFood : MonoBehaviour {

	public GameObject prefab;

	void OnTriggerEnter2D(Collider2D col) {
		if(col.gameObject.CompareTag(prefab.tag)){
			SpecialFoodManager specialFoodManager = col.gameObject.GetComponentInParent<SpecialFoodManager> ();
			specialFoodManager.Disable ();
		}
	}

}
