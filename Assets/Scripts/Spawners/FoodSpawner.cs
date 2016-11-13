using UnityEngine;
using System.Collections;

public class FoodSpawner : MonoBehaviour {

	public GameObject prefab;
	public GameObject parentObject;
	public Rect spawnZone;
	public bool showGizmo;
	public Color gizmoColor;

	void Start () {
		Spawn ();
	}

	public GameObject Spawn() {
		GameObject instance = (GameObject) Instantiate(prefab);
		instance.layer = gameObject.layer;
		if (parentObject) {
			instance.transform.SetParent (parentObject.transform);
		}
		instance.transform.position = GetRandomPositionInZone ();
		return instance;
	}

	Vector2 GetRandomPositionInZone() {
		float randomX, randomY;
		Vector2 pos;
		Vector3 posSnake = GameObject.FindGameObjectWithTag ("Player").transform.position;
		do {
			randomX = Random.Range (spawnZone.xMin, spawnZone.xMax);
			randomY = Random.Range (spawnZone.yMin, spawnZone.yMax);
		} while(false); // To do

		return new Vector2 (randomX, randomY);
	}

	void OnDrawGizmos(){
		if (showGizmo ) {
			GizmoUtils.DrawRectangle (spawnZone, gizmoColor);
		}
	}

}

