using UnityEngine;
using System.Collections;

public class Season {
	public float rainProbability;
	public float snowProbability;
	public float sunnyProbability;

	public int sunrise;
	public int sunset;

	public Season() {

	}

	public Season(float rain,float snow,float sun,int sunrise, int sunset) {
		rainProbability = rain;
		snowProbability = snow;
		sunnyProbability = sun;
		this.sunrise = sunrise;
		this.sunset = sunset;
	}

}
