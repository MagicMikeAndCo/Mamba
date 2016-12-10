using UnityEngine;
using System.Collections;

public class PowerUpManager : MonoBehaviour {
	public float waitTime;

	void OnEnable(){
		StartCoroutine (Timer());
	}

	IEnumerator Timer(){
		yield return new WaitForSeconds (waitTime);
		gameObject.SetActive (false);
	}

}
