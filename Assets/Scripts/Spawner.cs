using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class Spawner : MonoBehaviour {
	public Transform start;
	public Transform finish;
	public ConfigPanel config;
	public Director director;

	public static int AMOUNT_OF_ALIENS_TO_SPAWN = 1;

	private const int TIME_TO_SPAWN = 1; // In seconds.

	void ResetAlien(Alien alien)
	{
		alien.transform.position = start.transform.position;

		alien.transform.rotation = start.transform.rotation;

		alien.gameObject.SetActive(true);

		alien.Reset(RoutesManager.GetRandomRoute());
	}

	Alien CreateAlien()
	{
		var alien = AlienPool.Instance.SpawnAlien();

		ResetAlien(alien);

		return alien;
	}

	float elapsedTime = 0;
	void Update()
    {
		if (elapsedTime > TIME_TO_SPAWN)
        {
			elapsedTime = 0;

			for (int i = 0; i < AMOUNT_OF_ALIENS_TO_SPAWN; i ++)
            {
				CreateAlien();
            }
        }

		elapsedTime += Time.deltaTime;
    }
}
