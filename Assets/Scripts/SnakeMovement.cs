using UnityEngine;
using System.Collections;


public class SnakeMovement : MonoBehaviour {

	public float speed;
	private Vector2 direction = Vector2.right;
	private bool horizontal = false;
	private bool vertical = true;
	private Vector2 lastHeadPos;
	private bool keyPressed = false;

	void Start(){
		StartCoroutine (Move ());
	}

	void Update(){
		if (!keyPressed && Input.GetKey (KeyCode.RightArrow) && horizontal) {
			horizontal = false;
			vertical = true;
			keyPressed = true;
			direction = Vector2.right;
		}
		else if (!keyPressed && Input.GetKey (KeyCode.DownArrow) && vertical) {
			horizontal = true;
			vertical = false;
			keyPressed = true;
			direction = -Vector2.up;
		}
		else if (!keyPressed && Input.GetKey (KeyCode.LeftArrow) && horizontal) {
			horizontal = false;
			vertical = true;
			keyPressed = true;
			direction = -Vector2.right;
		}
		else if (!keyPressed && Input.GetKey (KeyCode.UpArrow) && vertical) {
			horizontal = true;
			vertical = false;
			keyPressed = true;
			direction = Vector2.up;
		}
			
	}
		
	void HeadMove(){	
		TailManager tailManager = GetComponentInParent<TailManager> ();
		Vector2 currentPos = transform.position;
		tailManager.SetLastHeadPosition (currentPos);
		transform.position = currentPos + direction * 10;
		tailManager.SetHeadRotation (transform ,direction);
		tailManager.TailMove ();
	}


	private IEnumerator Move(){
		while(true){
			HeadMove ();
			keyPressed = false;
			yield return new WaitForSeconds(speed);
		}

	}


}
