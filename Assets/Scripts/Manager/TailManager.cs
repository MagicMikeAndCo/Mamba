using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class TailManager : MonoBehaviour {
	public List<Transform> tails = new List<Transform>();
	public GameObject tailPrefab;
	public GameObject head;
	public GameObject parent;

	public void AddList(){
		GameObject newTail = (GameObject) Instantiate(tailPrefab);
		newTail.transform.position = head.transform.position;
		if (parent) {
			newTail.transform.SetParent (parent.transform);
		}
		tails.Insert (0, newTail.transform);
	}



	public void TailMove(Vector2 headPos){

		if (tails.Count > 0) {
			tails.Last ().position = headPos; 
			tails.Insert(0, tails.Last());
			tails.RemoveAt(tails.Count - 1);
		}
	}
}
