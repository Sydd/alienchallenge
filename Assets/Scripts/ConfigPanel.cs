using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using System;

public class ConfigPanel : MonoBehaviour {

	public Slider sliderRate;

	public Slider sliderSpeed;

	public Text txtRate;

	public Text txtSpeed;

	public Text txtInfo;

	public static int AmountsOfCocoonsTouched = 0;
	public static int AliensAmount = 0;
	public static int AverageAngle = 0;

	void Awake() 
	{

		sliderSpeed.onValueChanged.AddListener((float a) =>
		{
			Alien.speed = a;
			txtSpeed.text = a.ToString();
		});

		sliderRate.onValueChanged.AddListener((float b) =>
		{
			Spawner.AMOUNT_OF_ALIENS_TO_SPAWN = Mathf.RoundToInt(b);
			txtRate.text = Mathf.RoundToInt(b).ToString();
		});

		sliderRate.value = 0;
		txtRate.text = "0";
		Spawner.AMOUNT_OF_ALIENS_TO_SPAWN = 0;

		sliderSpeed.value = 10;
		txtSpeed.text = "10";
		Alien.speed = 10;

	}

	float elapsedTime = 0;
	void Update()
	{

	}


}
