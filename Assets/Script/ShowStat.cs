using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShowStat : MonoBehaviour {

	public GameObject weatherGameObject;
	private Text stat;
	private weather_controller weather;

	// Use this for initialization
	void Start () {
		stat = GetComponent<Text> ();
		stat.fontSize = 70;
		weather = weatherGameObject.GetComponent<weather_controller> ();
	}
	
	// Update is called once per frame
	void Update () {
		string debugWeather = "";
		if (weather_controller.currentWeather == 0)
			debugWeather = "Rain ";
		else if (weather_controller.currentWeather == 1)
			debugWeather = "Snow ";
		else
			debugWeather = "Sunny ";

		string debugSeason = "";
		if (weather.gameTime.getSeason() == 0)
			debugSeason = "Spring ";
		else if (weather.gameTime.getSeason() == 1)
			debugSeason = "Summer ";
		else if (weather.gameTime.getSeason() == 2)
			debugSeason = "Fall ";
		else 
			debugSeason = "Winter ";

		//stat.text = //"Hour : "+weather.hour + " Day : "+ weather.day + " Year : "+ weather.year + ". Season "+ debugSeason + "Weather : " + debugWeather +".\n"
			//+
		//	"You life points : " + (TrafficController.maxJamPenalty - TrafficController.totalJamPenalty)
		//	;
	}

	void OnGUI() {
		Rect rect = new Rect (1500,60, 600, 50);
		GUIStyle myStyle = new GUIStyle (GUI.skin.button);
		myStyle.fontSize = 30;
		string Info = "Score : " + (TrafficController.maxJamPenalty - TrafficController.totalJamPenalty)
			;
		GUI.Box(rect, Info,myStyle);

	}
}
