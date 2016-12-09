using ProgressBar;
using System.Collections;
using UnityEngine;

public class TimerProgressionBar : MonoBehaviour
{
	ProgressBarBehaviour BarBehaviour;
	float UpdateDelay = 0.1f;
	float timer = 5f;
	int timeElapsed = 0;

	public void OnEnable(){
		timeElapsed = 0;
		StartCoroutine ("Timer");
		BarBehaviour.TransitoryValue = 0;
		BarBehaviour.Value = 0;
	}

	public void OnDisable(){
		
		StopCoroutine ("Timer");

		//BarBehaviour.DecrementValue(7220);

	}



	IEnumerator Timer ()
	{
		BarBehaviour = GetComponent<ProgressBarBehaviour>();
		while (true)
		{
			yield return new WaitForSeconds(UpdateDelay / timer);
			BarBehaviour.Value += 1f;
			timeElapsed += 1;
		//	print("new value: " + BarBehaviour.Value);

		}

	}

	public int getTime(){
		return timeElapsed;
	}


	public void Disable(){
		if (BarBehaviour.isDone) {
			//print("new value: " + BarBehaviour.Value);
		}
	}

}	