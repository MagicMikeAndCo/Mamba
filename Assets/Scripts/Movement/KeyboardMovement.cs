using UnityEngine;
using System.Collections;

public class KeyboardMovement : MonoBehaviour {

	public float speed;
	private Vector2 dir = Vector2.up;
	private bool horizontal = true;
	private bool vertical = false;

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
		Vector2 pos = transform.position;
		pos += dir * speed * Time.deltaTime;
		transform.position = pos;
	}
}
