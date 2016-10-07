using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	public LevelManager lvlmnger;
	public GameObject car;
	public Transform[] iniLocation;
	public Transform[] targetLocation;
	public int carNum;
	private float bornTime = 0.6f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		bornTime -= Time.deltaTime;
		if (carNum > 0 && bornTime<0) {
			Transform iniLoc = iniLocation [Random.Range (0, iniLocation.Length)];
			GameObject newCar = Instantiate (car, iniLoc.position, Quaternion.identity) as GameObject;
			newCar.GetComponent<SampleAgentScript>().target = targetLocation [Random.Range (0, targetLocation.Length)];
			carNum--;
			bornTime = 0.6f;
		}

		//check if game over
		if (TrafficController.maxJamPenalty < TrafficController.totalJamPenalty) {
			GameOver ();
		}
	}
	public void destroyCar(){
			carNum++;
	}

	public void GameOver() {
		lvlmnger.LoadLevel ("Lose");
		//show stat here

		//now reset all static variables
		TrafficController.totalJamPenalty = 0;
		weather_controller.currentWeather = 2;
		weather_controller.previousWeather = 2;

	}
}
