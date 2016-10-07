using UnityEngine;
using System.Collections;
using System;


public class CustomTime{
	//1 year : 100 days : 
	//1 day : 24 hours  : 5 real time minutes
	//1 hour is a unit
	public static int hour = 1;
	public static int day = 24 * hour;
	public static int year = 100 * day;
	public static float timeSpeed = 100f;
	//public static Season Spring = new Season(0.3f,0.2f,0.5f,0.6f);
	//public static Season Summer = new Season(0.5f,0f,0.5f,0.8f) ;
	//public static Season Fall = new Season(0.6f,0.1f,0.3f,0.6f);
	//public static Season Winter = new Season(0.2f,0.6f,0.2f,0.3f);

	public static Season[] fourSeasons = {new Season(0.3f,0.2f,0.5f,6,20),new Season(0.3f,0f,0.7f,4,21),new Season(0.6f,0.1f,0.3f,6,20),new Season(0.2f,0.6f,0.2f,8,18)};

	//start and current time are multiple of unitTime
	private int startTime;
	private int currentTime;



	public CustomTime() {
		startTime = 0;
		currentTime = startTime;
	}
		

	//increase currentTime 1 hour
	public void increaseOneHour() {
		currentTime += hour;
	}

	//get current hour
	public int getHour() {
		return (currentTime/hour) % 24;
	}
	//get current day
	public int getDay() {
		return (currentTime/day) % 100 + 1;
	}
	//get current year
	public int getYear() {
		return currentTime / year + 1;
	}

	//get Season() 
	//0 : Spring, 1: Summer, 2: Fall, 3: Winter
	public int getSeason() {
		int season = 0;
		int currentday = getDay ();
		int quater = year / (4 * day);
		if (currentday <= quater) {
			season = 0;
		} else if (currentday <= 2 * year / (4 * day)) {
			season = 1;
		} else if (currentday <= 3 * year / (4 * day)) {
			season = 2;
		} else {
			season = 3;
		}
		return season;
	}

	public int getCurrentTime() {
		return currentTime;
	}



}

