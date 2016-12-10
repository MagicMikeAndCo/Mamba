using UnityEngine;
using System.Collections;

public class SpeedManager : AbstractSingleton<SpeedManager>  {

	private float speed;
	public float minSpeed;
	public SnakeMovement snakeMovement;

	public override void Initialize (){
		speed = snakeMovement.getSpeed ();
	}

	public void addSpeed(){
		speedModificator (0.5f);
	}

	public void superSpeed(){
		speedModificator (8f);
	}

	public void slowSpeed(){
		speedModificator (-4f);
	}

	private void speedModificator(float modifier){
		float newSpeed = speed;
		newSpeed -= ((newSpeed * modifier) / 100);
		if (newSpeed > minSpeed) {
			snakeMovement.setSpeed (minSpeed);
			speed = minSpeed;
		} else {
			snakeMovement.setSpeed (newSpeed);
			speed = newSpeed;
		}

		Debug.Log (speed);


	}


}
