using UnityEngine;
using System.Collections;

public class SpeedManager : AbstractSingleton<SpeedManager>  {

	private float speed;
	public SnakeMovement snakeMovement;

	public override void Initialize (){
		speed = snakeMovement.getSpeed ();
	}

	public void addSpeed(){
		speedModificator (0.5f);
	}

	public void superSpeed(){
		speedModificator (10f);
	}

	public void slowSpeed(){
		speedModificator (-10f);
	}

	private void speedModificator(float modifier){
		speed -= (speed * modifier) / 100;
		snakeMovement.setSpeed (speed);
	}


}
