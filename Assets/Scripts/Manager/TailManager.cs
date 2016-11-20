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
		Vector2 newPos;
		for(int i = 0; i < tails.Count; i++){
			newPos = new Vector2(tails.ElementAt(i).position.x, tails.ElementAt(i).position.y);
			if (headPos.x == newPos.x || headPos.y == newPos.y) {
				//Debug.Log ("1if " + Mathf.Abs (headPos.x - pos.x) + " " + Mathf.Abs (headPos.y - pos.y));
				newPos += direction * speed * Time.deltaTime;
				tails.ElementAt(i).position = newPos;
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
				Vector2 oldPos;
				for (int j = i + 1; j < tails.Count; j++) {
					oldPos = new Vector2(tails.ElementAt(j-1).position.x, tails.ElementAt(j-1).position.y);
					tails.ElementAt (j).position = oldPos;
				}
				tails.ElementAt(i).position = newPos;

			}
			else {
				//Debug.Log("1else");
				//To do rotation newPos
			}	
			headPos = tails.ElementAt(i).position;
		}


	}
}
