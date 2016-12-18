using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameMenuManager : MonoBehaviour {

	public string sceneToStart;

	public void Play(){
		//Debug.Log ("click");
		SceneManager.LoadScene (sceneToStart);
	}

	public void Quit(){
		Application.Quit ();
	}
}
