using UnityEngine;
using System.Collections;

public class weather_controller : MonoBehaviour {
	public ParticleSystem rain;
	public ParticleSystem snow;
	public CustomTime gameTime;
	public Light sun;
	public int hour, day, year;
	public Season season;
	private float timeSpotToChangeWeather;
	//0: for rain, 1 for snow, 2 for sunny
	public static int currentWeather;
	public static int previousWeather;
	public static bool isWeatherUpdated;

	// Use this for initialization
	void Start () {
		gameTime = new CustomTime ();
		hour = gameTime.getHour ();
		day = gameTime.getDay ();
		year = gameTime.getYear ();
		season = CustomTime.fourSeasons[gameTime.getSeason()];
		currentWeather = 2;
		previousWeather = 2;
		isWeatherUpdated = false;
		timeSpotToChangeWeather = Random.Range (6f,23f);
		UpdateWeather ();



		InvokeRepeating("IncreaseOneHour",0f,Time.deltaTime * CustomTime.timeSpeed);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void IncreaseOneHour() {
		string debugWeather = "";
		if (currentWeather == 0)
			debugWeather = "Rain ";
		else if (currentWeather == 1)
			debugWeather = "Snow ";
		else
			debugWeather = "Sunny ";
		//Debug.Log (debugWeather+".Hour: "+hour+" Day: "+day+" Year: "+year+ " Speed "+CustomTime.timeSpeed+ " Season "+ gameTime.getSeason());
		gameTime.increaseOneHour ();
		hour = gameTime.getHour ();

		if (hour == 0) {
			day = gameTime.getDay ();
		}


		if (hour == Mathf.Floor (timeSpotToChangeWeather)) {
			UpdateWeather ();
		}
			
		UpdateDayNightIntensity ();


		if (day == 1) {
			year = gameTime.getYear ();
		}
		season = CustomTime.fourSeasons[gameTime.getSeason()];


	}

	void UpdateDayNightIntensity() {
		/*
		if (hour > season.sunrise && hour < 12) {
			if (currentWeather == 0 || currentWeather == 1) {
				sun.intensity += 0.05f;
			} else {
				sun.intensity += 0.1f;
			}
		} else if (hour >= 12 && hour <= 16) {

		} else if (hour > 16 && hour < season.sunset) {
			sun.intensity -= 0.05f;
		} else {
			if (currentWeather == 0 || currentWeather == 1) {
				setSunIntensity (0.5f);
			} else {
				setSunIntensity (1f);
			}
		}
		*/
		// if 0-12 increase;
		if (hour > 0f && hour < 12f) {
			sun.intensity = hour / 12f;
			sun.intensity = Mathf.Clamp (sun.intensity, 0.2f, 1f);
		}

		// if 12-24 decrease
		if (hour > 12f && hour < 24f) {
			sun.intensity = (24f - hour) / 12f;
			sun.intensity = Mathf.Clamp (sun.intensity, 0.2f, 1f);
		}

	}

	void UpdateWeather() {
		isWeatherUpdated = true;
		previousWeather = currentWeather;
		
		float value = Random.Range (0f,1f);
		if (value <= season.rainProbability) {
			currentWeather = 0;
			setRate (rain.emission, 300f);
			setRate (snow.emission, 0f);
		} else if (value <= (season.rainProbability + season.snowProbability)) {
			currentWeather = 1;
			setRate (rain.emission, 0f);
			setRate (snow.emission, 300f);
		} else {
			currentWeather = 2;
			setRate (rain.emission, 0f);
			setRate (snow.emission, 0f);
			//sunny
		}

		timeSpotToChangeWeather = Random.Range (0f,23f);
	}

	void setRate(ParticleSystem.EmissionModule emission,float rate) {
		var temp = emission.rate;
		temp.constantMax = rate;
		emission.rate = temp;
	}

	void setSunIntensity(float intensity) {
		sun.intensity = intensity;
	}
		
}
