using UnityEngine;
using System.Collections;

public class TimeController : MonoBehaviour {

	public void SpeedUp() {
		CustomTime.timeSpeed = 0.001f;
	}

	public void Normal() {
		CustomTime.timeSpeed = 50f;
	}
}
