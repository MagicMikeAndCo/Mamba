using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class TailManager : MonoBehaviour {
	public LinkedList<Transform> tails = new LinkedList<Transform>();
	public GameObject tailPrefab;
	public GameObject head;
	public GameObject firstTail;
	public GameObject secondTail;
	public GameObject parent;

	void Start(){
		tails.AddFirst (firstTail.transform);
		tails.AddFirst (secondTail.transform);
	}

	public void AddList(){
		GameObject newTail = (GameObject) Instantiate(tailPrefab);
		newTail.transform.position = tails.Last().transform.position;
		if (parent) {
			newTail.transform.SetParent (parent.transform);
		}
		tails.AddLast (newTail.transform);
	}

		
	public void TailMove(Vector2 headPos, Vector2 direction, float speed){
		//Debug.Log(direction.x + " " + direction.y);
		//Debug.Log (headPos.x == pos.x);
		//Debug.Log (headPos.y == pos.y);
		foreach(Transform tail in tails){
			Vector2 newPos = new Vector2(tail.position.x, tail.position.y);
			if (headPos.x == newPos.x || headPos.y == newPos.y) {
				//Debug.Log ("1if " + Mathf.Abs (headPos.x - pos.x) + " " + Mathf.Abs (headPos.y - pos.y));
				newPos += direction * speed * Time.deltaTime;
				tail.position = newPos;
			} 
			else if ((direction.x != 0 && Mathf.Abs (headPos.x - newPos.x) >= 10) || (direction.y != 0 && Mathf.Abs (headPos.y - newPos.y) >= 10)) {
				//Debug.Log ("1elseif " + Mathf.Abs (headPos.x - pos.x) + " " + Mathf.Abs (headPos.y - pos.y));
				if (direction.x != 0) { // right or left
					//Debug.Log ("2if");
					newPos.y = headPos.y;	
				} else { // up or down
					//Debug.Log ("2else");
					newPos.x = headPos.x;	

				}
				tail.position = newPos;

			}
			else {
				//Debug.Log("1else");
				//To do rotation newPos
			}	
			headPos = tail.position;
		}


	}
}
