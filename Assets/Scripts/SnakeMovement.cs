using UnityEngine;
using System.Collections;


public class SnakeMovement : MonoBehaviour {

	public float speed;
	private Vector2 direction = Vector2.right;
	private bool horizontal = false;
	private bool vertical = true;

	void Update(){
		if (Input.GetKey (KeyCode.RightArrow) && horizontal) {
			horizontal = false;
			vertical = true;
			direction = Vector2.right;
		}
		else if (Input.GetKey (KeyCode.DownArrow) && vertical) {
			horizontal = true;
			vertical = false;
			direction = -Vector2.up;
		}
		else if (Input.GetKey (KeyCode.LeftArrow) && horizontal) {
			horizontal = false;
			vertical = true;
			direction = -Vector2.right;
		}
		else if (Input.GetKey (KeyCode.UpArrow) && vertical) {
			horizontal = true;
			vertical = false;
			direction = Vector2.up;
		}

		HeadMove ();
	}
		
	void HeadMove(){	
		Vector2 currentPos = transform.position;  
		transform.position = currentPos + direction * speed * Time.deltaTime;
		TailManager tailManager = GetComponentInParent<TailManager> ();
		tailManager.TailMove (transform.position, direction, speed);
	}

}
