using UnityEngine;
using System.Collections;


public class SnakeMovement : MonoBehaviour {

	public float speed;
	private Vector2 dir = Vector2.right;
	private bool horizontal = false;
	private bool vertical = true;

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

		HeadMove ();
	}
		
	void HeadMove(){	
		Vector2 currentPos = transform.position;  
		transform.position = currentPos + dir * speed * Time.deltaTime;
		TailManager tailManager = GetComponentInParent<TailManager> ();
		tailManager.TailMove (currentPos);
	}

}
