using UnityEngine;
using System.Collections;

public class BombManager : MonoBehaviour {
	public float waitTime;
	public GameObject animation;

	void OnEnable(){
		StartCoroutine (Timer());
	}

	IEnumerator Timer(){
		yield return new WaitForSeconds (waitTime);
		Instantiate (animation, gameObject.transform.position, Quaternion.identity);
		gameObject.SetActive (false);
	}

}
