using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Alien : MonoBehaviour {
	public Canvas ui;
	public Text txtAlien;
	public Transform target;
	public static float speed;
	public List<Transform> targets;
	public Vector3 offset;

	private int nextTarget;

	public int CocoonsTouched;

	public void Reset(List<Transform> targets)
	{
		GetComponent<Animator>().Play("Grounded");

		GetComponent<Animator>().SetFloat("Forward", 1f);

		nextTarget = 0;

		this.targets = targets;

		target = targets[nextTarget];
		
		if(txtAlien == null) txtAlien = ui.GetComponentInChildren<Text>();

		txtAlien.text = "0";

		Director.aliensAlive++;

	}

	void Update () {
		if(target != null)
		{
			var delta = target.position - transform.position;
			delta.y = 0f;
			var deltaLen = delta.magnitude;
			var move = Mathf.Min(speed * Time.deltaTime, deltaLen);
			if(deltaLen <= 5f)
            {
				if(nextTarget == targets.Count)
                {
					target = null;
                }
                else
                {
					target = targets[nextTarget++];
                }
            }
			else
			{
				var direction = delta / deltaLen;
				transform.forward = Vector3.Slerp(transform.forward, direction, 10f * Time.deltaTime);
				GetComponent<CharacterController>().Move(move * transform.forward + Vector3.down * 3f);
			}
		}		

		if(ui != null)
		{
			ui.transform.position = transform.position + offset;
		}
	}


	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Finish"))
        {
			gameObject.SetActive(false);
			Director.aliensAlive--;
        }

		if (other.CompareTag("Fire"))
        {
			CocoonsTouched++;
			Director.TouchCocoons++;
			txtAlien.text = CocoonsTouched.ToString();
		}
	}

	private void OnTriggerExit(Collider other)
    {

		if (other.CompareTag("Fire"))
		{
			CocoonsTouched--;
			txtAlien.text = CocoonsTouched.ToString();
		}
	}
}
