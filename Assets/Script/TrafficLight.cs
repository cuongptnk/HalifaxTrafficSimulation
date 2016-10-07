using UnityEngine;
using System.Collections;

public class TrafficLight : MonoBehaviour {
	private float timeLeft = 15f;
	private bool green = true;
	private bool red = false;
	private bool lightColor;
	private Color greenLight = Color.green;
	private Color redLight = Color.red;

	// change color
	public Renderer rend;

	// Use this for initialization
	void Start () {
		lightColor = green;
		greenLight.a = 0.6f;
		redLight.a = 0.6f;

		rend = GetComponent<Renderer>();
		rend.material.color = greenLight;
	}
	
	// Update is called once per frame
	void Update () {
		timeLeft -= Time.deltaTime;
		if (timeLeft < 0f) {
			timeLeft = 15f;
			lightColor = !lightColor;
			if (lightColor == green) {
				rend.material.color = greenLight;
			} else {
				rend.material.color = redLight;
			}
		}
	}

	// Detect a car enter the traffic light zone
	void OnTriggerEnter(Collider other){
		if (other.tag == "car" && !lightColor) {
			// stop the car
			other.GetComponent<SampleAgentScript>().signalStop();
		}
	}
	// Detect a car stay in the traffic light zoon

	void OnTriggerStay(Collider other) {
		if (other.tag == "car" && lightColor) {
			// stop the car
			other.GetComponent<SampleAgentScript>().signalResume();
		}
	}
}
