using UnityEngine;
using System.Collections;

public class PowerUpManager : MonoBehaviour {
	public float waitTime;
	private float time;
	private SpriteRenderer renderer;

	void OnEnable(){
		time = 0;
		renderer = gameObject.GetComponent<SpriteRenderer> ();
		StartCoroutine (Visibility());
		StartCoroutine (Timer());
	}

	void Update(){
		time += Time.deltaTime;
	}

	IEnumerator Visibility(){
		while(time <= waitTime){
			if(time > (waitTime * 0.666666f)){ // 2/3 of waitTime
				float colorA;
				if (renderer.color.a == 0) {
					colorA = 255f; //visible
				} else {
					colorA = 0f; //invisible
				}
				renderer.color = new Color (255, 255, 255, colorA);
			}
			yield return new WaitForSeconds (0.19f);
		}
	}

	IEnumerator Timer(){
		yield return new WaitForSeconds (waitTime);
		gameObject.SetActive (false);
	}

}
