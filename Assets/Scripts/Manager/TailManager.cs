using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class TailManager : MonoBehaviour {
	private List<Transform> tails = new List<Transform>();
	public GameObject tailPrefab;
	public GameObject head;
	public GameObject firstTail;
	public GameObject endTail;
	public GameObject parent;
	private Vector2 lastHeadPosition;

	void OnEnable(){
		tails.Add (firstTail.transform);
		tails.Add (endTail.transform);
	}

	public void AddList(){
		GameObject newTail = (GameObject) Instantiate(tailPrefab);
		newTail.transform.position = lastHeadPosition;
		if (parent) {
			newTail.transform.SetParent (parent.transform);
		}
		tails.Insert(tails.Count - 1, newTail.transform);
	}

		
	public void TailMove(Vector2 headPos){
		Transform penultimatePos;
		Transform lastPos;
		lastPos = tails [tails.Count - 1];
		lastPos.position = tails[tails.Count - 2].position;
		penultimatePos = tails [tails.Count - 2];
		penultimatePos.position = lastHeadPosition;
		tails.Insert (0, penultimatePos);
		tails.RemoveAt (tails.Count - 2);
		correctLastTailPosition (tails[tails.Count - 2].position);
	}

	public void SetLastHeadPosition(Vector2 lastPos){
		this.lastHeadPosition = lastPos;
	}

	public void SetHeadRotation (Transform head, Vector2 direction){
		if (direction == Vector2.up) {
			head.eulerAngles = new Vector3(0, 0, 180);
		}
		else if (direction == Vector2.down){
			head.eulerAngles = new Vector3(0, 0, 0);			
		}
		else if (direction == Vector2.left){
			head.eulerAngles = new Vector3(0, 0, 270);			
		}
		else if (direction == Vector2.right){
			head.eulerAngles = new Vector3(0, 0, 90);
		}
	}


	private void correctLastTailPosition(Vector2 lastTailPos){
		Transform endTail = tails [tails.Count - 1];
		Vector2 endTailPos = endTail.position;
		if (endTailPos.x == lastTailPos.x) {
			if (endTailPos.y < lastTailPos.y) {
				endTail.eulerAngles = new Vector3 (0, 0, -90); 
			} else {
				endTail.eulerAngles = new Vector3 (0, 0, 90);
			}
		} else {
			if (endTailPos.x < lastTailPos.x) {
				endTail.eulerAngles = new Vector3 (0, 0, 180);
			} else {
				endTail.eulerAngles = new Vector3 (0, 0, 360);
			}
		}
	}

}
