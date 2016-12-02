using UnityEngine;
using System.Collections;

public class SpecialFoodManager : MonoBehaviour {

	public int nbEatenFood;
	public GameObject prefab;
	public GameObject progressBar;

	public void IncrementEatenFood(){
		nbEatenFood++;
		if (nbEatenFood == 5) {
			nbEatenFood = 0;
			if (!prefab.activeSelf) {
				SpawnSpecialFood ();
				prefab.SetActive (true);
				progressBar.SetActive (true);			}
		}
	}

	private void SpawnSpecialFood(){
		FoodSpawner foodSpawner = gameObject.GetComponentInParent<FoodSpawner> ();
		foodSpawner.Spawn (prefab);
	}

	public void Disable(){
		prefab.SetActive (false);
		progressBar.SetActive (false);
	}


}
