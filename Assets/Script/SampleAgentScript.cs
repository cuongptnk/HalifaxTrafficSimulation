using UnityEngine;
using System.Collections;

public class SampleAgentScript : MonoBehaviour {

	private float type;
	public int jamPenalty;
	private bool isJamCounted = false;

	
	
	public Transform target;
	public NavMeshAgent agent;
	private bool inRedZone=false;

	// Use this for initialization
	void Start () {
		type = Random.Range (0f,2f);
		if (type <= 1f) {
			//normal car
			jamPenalty = 1;

		} else {
			//ambulence car
			jamPenalty = 3;
			//set diffrent color
			GetComponent<Renderer>().material.color =  new Color(255f,128,0f);
		}

		agent = GetComponent<NavMeshAgent> ();
		agent.speed = Random.Range (4f,7f);
		Debug.Log (agent.speed);
		Debug.Log (jamPenalty);
		
	}
	
	// Update is called once per frame
	void Update () {
		agent.SetDestination (target.position);
		if (distance () < 5.0f) {
			Destroy (gameObject);
		}
		if (gameObject) {
			if (agent.speed > 0) {
				if (isJamCounted) {
					TrafficController.totalJamPenalty -= jamPenalty;
				}
				isJamCounted = false;

				//slow down when rain or snow
				//resume speed when sun
				//0 for rain, 1 for snow, 2 for sunny

				//from sun to rain/snow : slow down
				if (weather_controller.isWeatherUpdated) {
					if (weather_controller.previousWeather == 2 && weather_controller.currentWeather < 2) {
						agent.speed *= Random.Range (0.5f, 0.9f);
					} 

					//from rain/snow to sunny : speed up
					else if (weather_controller.previousWeather < 2 && weather_controller.currentWeather == 2) {
							agent.speed *= Random.Range (1.1f, 1.5f);
						}

					weather_controller.isWeatherUpdated = false;
				}
			}
			else if (agent.speed == 0 && !isJamCounted) {
				Debug.Log ("A car stop");
				TrafficController.totalJamPenalty += jamPenalty;
				isJamCounted = true;
			}
		}
	}
	
	void FixedUpdate(){
		RaycastHit hit;
		Vector3 fwd = transform.TransformDirection(Vector3.forward);

		if (Physics.Raycast (transform.position, fwd, out hit, 3f)) {
			if (hit.collider.tag == "car") {
				agent.speed = 0f;
			} 
		} /*else {
			// if not in the red light zone, move
			if (inRedZone) {
				agent.speed = 0f;
			} else {
				agent.speed = 4f;
			}
		}*/
		else if (inRedZone) {
			agent.speed = 0f;
		} else {
			agent.speed = 4f;
		}
	}
	
	
	float distance(){
		return Vector3.Distance(gameObject.transform.position, target.position);
	}
	
	// if a signal light ahead and it is red, stop
	public void signalStop(){
		inRedZone = true;
		agent.speed = 0f;
	}
	// if a signal light ahead and it turns green, go
	public void signalResume(){
		//agent.Resume();	
		inRedZone = false;
		agent.speed = 4f;
	}

}
