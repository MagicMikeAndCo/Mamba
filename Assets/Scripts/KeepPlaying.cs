using UnityEngine;
using System.Collections;

public class KeepPlaying : MonoBehaviour {

	private GameObject[] music;

	void Start(){
		music = GameObject.FindGameObjectsWithTag ("gameMusic");
		Destroy (music[1]);
	}
		
	void Awake () {
		DontDestroyOnLoad (transform.gameObject);
	}
}

