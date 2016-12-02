using UnityEngine;
using System.Collections;

public class FoodSpawner : MonoBehaviour {

	public GameObject prefab;
	public GameObject parentObject;
	public Rect spawnZone;
	public bool showGizmo;
	public Color gizmoColor;
	public float minDistance;
	private GameObject instance;

	void Start () {
		instance = (GameObject) Instantiate(prefab);
		instance.layer = gameObject.layer;
		if (parentObject) {
			instance.transform.SetParent (parentObject.transform);
		}

		Spawn (instance);
	}

	public GameObject Spawn(){
		return Spawn (instance);
	}

	public GameObject Spawn(GameObject instance) {
		Vector2 pos = GetRandomPositionInZone ();
		if (pos == Vector2.zero) {
			new WaitForEndOfFrame ();
			Debug.Log ("Waiting next Frame");
			return Spawn (instance);
		}
		instance.transform.position = pos;

		return instance;
	}

	public Vector2 GetRandomPositionInZone() {
		float randomX, randomY;
		int maxAttempt = 5;
		for(int i = 0; i < maxAttempt; i++){
			randomX = (int) Random.Range (spawnZone.xMin, spawnZone.xMax);
			randomY = (int) Random.Range (spawnZone.yMin, spawnZone.yMax);
			Vector2 pos = new Vector2(randomX, randomY);
			if(!Physics2D.OverlapCircle(pos, minDistance)){
				return pos;
			}
			Debug.Log ("Spawn Failed " + i);
		}

		return Vector2.zero;
	}

	void OnDrawGizmos(){
		if (showGizmo ) {
			GizmoUtils.DrawRectangle (spawnZone, gizmoColor);
		}
	}

}

