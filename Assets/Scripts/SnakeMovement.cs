using UnityEngine;
using System.Collections;


public class SnakeMovement : MonoBehaviour {

	public float speed;
	private Vector2 direction = Vector2.right;
	private bool horizontal = false;
	private bool vertical = true;

	void Start(){
		StartCoroutine (Move ());
	}

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
			
	}
		
	void HeadMove(){	
		TailManager tailManager = GetComponentInParent<TailManager> ();
		Vector2 currentPos = transform.position;  
		transform.position = currentPos + direction * 10;
		tailManager.TailMove ();
	}


	private IEnumerator Move(){
		while(true){
			HeadMove ();
			yield return new WaitForSeconds(speed);
		}

	}


}
