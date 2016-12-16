using UnityEngine;
using System.Collections;

public class BombManager : MonoBehaviour {
	public float waitTime;
	public GameObject animation;
	private SpriteRenderer renderer;

	void OnEnable(){ 
		renderer = gameObject.GetComponent<SpriteRenderer> ();
		renderer.color = new Color (255, 255, 255, 255);
		StartCoroutine (Timer());
	}

	IEnumerator Timer(){
		yield return new WaitForSeconds (waitTime);
		renderer.color = new Color (255, 255, 255, 0);
		GameObject instance = (GameObject) Instantiate (animation, gameObject.transform.position, Quaternion.identity);
		StartCoroutine (ExplosionDestroyTimer(instance));
	}

	IEnumerator ExplosionDestroyTimer(GameObject instance){
		yield return new WaitForSeconds (1f);
		Destroy (instance);
		gameObject.SetActive (false);
	}

}
