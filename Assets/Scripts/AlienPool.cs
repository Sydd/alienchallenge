using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienPool : MonoBehaviour {

    public static AlienPool Instance;

    public int AmountToLoad = 10;

    public Alien alien;

    public GameObject alienUI;

    public List<Alien> aliens;

    void Awake()
    {
        Instance = this;

        aliens = new List<Alien>();

        for (int i = 0; i < AmountToLoad; i++)
        {
            Alien spawned = CreateAlien();

            aliens.Add(spawned);
        }
    }

    public Alien SpawnAlien()
    {
        foreach  (Alien alienToReturn in aliens)
        {
            if (!alienToReturn.isActiveAndEnabled) return alienToReturn;
        }

        Alien spawned = CreateAlien();

        aliens.Add(spawned);

        return spawned;       
    }


    private Alien CreateAlien()
    {
        Alien spawned = Instantiate(alien,this.transform);

        spawned.ui = Instantiate(alienUI,spawned.transform).GetComponent<Canvas>();

        spawned.ui.transform.localScale *= 0.1f;

        spawned.gameObject.SetActive(false);

        return spawned;
    }

    public float GetAVGAngles()
    {
        int amountOfAngles = 0;
        float totalAngles = 0;
        foreach (Alien alien in aliens)
        {
            if (alien.isActiveAndEnabled)
            {
                totalAngles += alien.transform.rotation.eulerAngles.y;
                amountOfAngles++;
            }
        }

        return totalAngles / amountOfAngles;
    }
}
