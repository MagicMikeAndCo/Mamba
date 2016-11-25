﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class TailManager : MonoBehaviour {
	public List<Transform> tails = new List<Transform>();
	public GameObject tailPrefab;
	public GameObject head;
	public GameObject firstTail;
	public GameObject secondTail;
	public GameObject parent;
	private Vector2 lastHeadPosition;

	void OnEnable(){
		//Debug.Log (firstTail.transform.localPosition);
		//Debug.Log (secondTail.transform.localPosition);
	}

	public void AddList(){
		GameObject newTail = (GameObject) Instantiate(tailPrefab);
		newTail.transform.position = lastHeadPosition;
		if (parent) {
			newTail.transform.SetParent (parent.transform);
		}
		tails.Add(newTail.transform);
	}

		
	public void TailMove(){
		if (tails.Count != 0) {
			Transform lastPos = tails [tails.Count - 1];
			lastPos.position = lastHeadPosition;
			tails.Insert (0, lastPos);
			tails.RemoveAt (tails.Count - 1);
		}
	}

	public void SetLastHeadPosition(Vector2 lastPos){
		this.lastHeadPosition = lastPos;
	}
}
