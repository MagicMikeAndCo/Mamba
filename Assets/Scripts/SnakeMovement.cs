using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class SnakeMovement : MonoBehaviour {

	public float speed;
	private Vector2 dir = Vector2.right;
	private bool horizontal = false;
	private bool vertical = true;
	private List<Transform> tail = new List<Transform>();

	void Update(){
		if (Input.GetKey (KeyCode.RightArrow) && horizontal) {
			horizontal = false;
			vertical = true;
			dir = Vector2.right;
		}
		else if (Input.GetKey (KeyCode.DownArrow) && vertical) {
			horizontal = true;
			vertical = false;
			dir = -Vector2.up;
		}
		else if (Input.GetKey (KeyCode.LeftArrow) && horizontal) {
			horizontal = false;
			vertical = true;
			dir = -Vector2.right;
		}
		else if (Input.GetKey (KeyCode.UpArrow) && vertical) {
			horizontal = true;
			vertical = false;
			dir = Vector2.up;
		}

		Move ();
	}

	void Move(){
		Vector2 currentPos = transform.position;  
		transform.position = currentPos + dir * speed * Time.deltaTime;
		if (tail.Count > 0) {
			tail.Last ().position = currentPos; 
			tail.Insert(0, tail.Last());
			tail.RemoveAt(tail.Count - 1);
		
		}
	}
}
