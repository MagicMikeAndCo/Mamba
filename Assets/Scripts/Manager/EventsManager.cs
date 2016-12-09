using UnityEngine;
using System.Collections;

public class EventsManager : MonoBehaviour {

	public delegate void DieAction();
	public event DieAction OnDie;
	public delegate void EatAction();
	public event EatAction OnEat;

	public void Die(){
		if (OnDie != null) {
			OnDie ();
		}
	}

	public void Eat(){
		if (OnEat != null) {
			OnEat ();
		}
	}
		
}
