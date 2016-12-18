using UnityEngine;
using System.Collections;

public class FoodSpawner : MonoBehaviour {

	public GameObject prefab;
	public GameObject parentObject;
	public GameObject speedUp;
	public GameObject slowDown;
	public GameObject bomb;
	public Rect spawnZone;
	public bool showGizmo;
	public Color gizmoColor;
	public float minDistance;
	private GameObject instance;
	public int nbPowerUps;
	private const int SPEED_UP = 1;
	private const int SLOW_DOWN = 2;

	void Start () {
		instance = prefab;

		Spawn (instance);
		instance.SetActive (true);
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
			randomX = Mathf.Ceil (randomX / 10) * 10 + 5;
			randomY = Mathf.Ceil (randomY / 10) * 10 + 5;
			Vector2 pos = new Vector2(randomX, randomY);
			//Debug.Log (pos);
			if(!Physics2D.OverlapCircle(pos, minDistance)){
				return pos;
			}
			//Debug.Log ("Spawn Failed " + i);
		}

		return Vector2.zero;
	}

	void OnDrawGizmos(){
		if (showGizmo ) {
			GizmoUtils.DrawRectangle (spawnZone, gizmoColor);
		}
	}

	public void SpawnPowerUp(){
		GameObject powerUp;
		int random = Random.Range (1, nbPowerUps + 1);
		if (random == SPEED_UP) {
			powerUp = speedUp;
		} else if (random == SLOW_DOWN) {
			powerUp = slowDown;
		} else {
			powerUp = bomb;
		}
		Spawn (powerUp);
		powerUp.SetActive(true);
	}
		

}

