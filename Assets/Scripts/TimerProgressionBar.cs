using ProgressBar;
using System.Collections;
using UnityEngine;

public class TimerProgressionBar : MonoBehaviour
{
	ProgressBarBehaviour BarBehaviour;
	float UpdateDelay = 0.1f;
	float timer = 5f;
	int i = 0;

	public void OnEnable(){
		StartCoroutine ("blabla");
		BarBehaviour.TransitoryValue = 0;
		BarBehaviour.Value = 0;


	}

	public void OnDisable(){
		StopCoroutine ("blabla");

		//BarBehaviour.DecrementValue(7220);

	}



	IEnumerator blabla ()
	{
		BarBehaviour = GetComponent<ProgressBarBehaviour>();
		while (true)
		{
			yield return new WaitForSeconds(UpdateDelay / timer);
			BarBehaviour.Value += 1f;
			print("new value: " + BarBehaviour.Value);
			i++;
		}

	}


	public void Disable(){
		if (BarBehaviour.isDone) {
			print("new value: " + BarBehaviour.Value);
		}
	}

}	