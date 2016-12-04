using UnityEngine;
using System.Collections;

public class SpecialFoodManager : MonoBehaviour {

	public int nbEatenFoodActivation;
	private int nbEatenFood = 0;
	public GameObject prefab;
	public GameObject progressBar;
	public GameObject superFoodEffectPrefab;
	private GameObject superFoodEffect;

	public void IncrementEatenFood(){
		nbEatenFood++;
		if (nbEatenFood == nbEatenFoodActivation) {
			nbEatenFood = 0;
			if (!prefab.activeSelf) {
				SpawnSpecialFood ();
				superFoodEffect = (GameObject)Instantiate (superFoodEffectPrefab, prefab.transform.position, prefab.transform.rotation);
				prefab.SetActive (true);
				progressBar.SetActive (true);			
			}
		}
	}

	private void SpawnSpecialFood(){
		FoodSpawner foodSpawner = gameObject.GetComponentInParent<FoodSpawner> ();
		foodSpawner.Spawn (prefab);
	}

	public void Disable(){
		Destroy (superFoodEffect, 0.2f);
		prefab.SetActive (false);
		progressBar.SetActive (false);
	}
		
}
