using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Director : MonoBehaviour {
	public Spawner spawner;
	public ConfigPanel config;
	public static int aliensAlive = 0;
	public int hitsPerSecond = 0;
	public  float avgAngle = 0;

	public static int TouchCocoons = 0;

	float elapsedTime = 0;
	void Update() {


		//Update stats
		config.txtInfo.text =
			$"{aliensAlive} aliens alive"
			+ $"\n{hitsPerSecond} cocoons hits p/sec"
			+ $"\n{avgAngle:F2}° average angle"
			;

		if (elapsedTime > 1)
        {
			elapsedTime = 0;
			hitsPerSecond = TouchCocoons;
			TouchCocoons = 0;
			avgAngle = AlienPool.Instance.GetAVGAngles();
		} 

		elapsedTime += Time.deltaTime;
	}
}
