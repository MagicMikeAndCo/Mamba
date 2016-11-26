using UnityEngine;
using System.Collections;

public class FoodSpawner : MonoBehaviour {

	public GameObject prefab;
	public GameObject parentObject;
	public Rect spawnZone;
	public bool showGizmo;
	public Color gizmoColor;
	public float minDistance;

	void Start () {
		Spawn ();
	}

	public GameObject Spawn() {
		Vector2 pos = GetRandomPositionInZone ();
		if (pos == Vector2.zero) {
			new WaitForEndOfFrame ();
			Debug.Log ("Waiting next Frame");
			Spawn ();
		}
		GameObject instance = (GameObject) Instantiate(prefab, pos, Quaternion.identity);
		instance.layer = gameObject.layer;
		if (parentObject) {
			instance.transform.SetParent (parentObject.transform);
		}
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

