using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EatManager : MonoBehaviour {

	public EventsManager eventsManager;
	public List<AbstractEatBehaviour> eatBehaviours;

	void Awake(){
		if (!eventsManager) {
			eventsManager = GetComponentInParent<EventsManager> ();
		}
		foreach (var item in GetComponentsInChildren<AbstractEatBehaviour>()) {
			eatBehaviours.Add (item);
		}
	}

	void OnEnable(){
		eventsManager.OnEat += Eat;
	}

	void OnDisable(){
		eventsManager.OnEat -= Eat;
	}

	void Eat(){
		foreach (var item in eatBehaviours) {
			item.Eat (gameObject);
		}
	}
}
