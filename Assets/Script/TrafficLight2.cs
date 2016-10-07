using UnityEngine;
using System.Collections;

public class TrafficLight2 : MonoBehaviour {
	private float timeLeft = 15f;
	private bool green = true;
	private bool red = false;
	private bool lightColor;

	// change color
	public Renderer rend;

	private Color greenLight = Color.green;
	private Color redLight = Color.red;

	// Use this for initialization
	void Start () {
		lightColor = red;

		rend = GetComponent<Renderer>();
		greenLight.a = 0.6f;
		redLight.a = 0.6f;

		rend = GetComponent<Renderer>();
		rend.material.color = redLight;
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
