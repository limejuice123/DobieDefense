using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameTimer : MonoBehaviour 
{
	public float timer;

	void Start () 
	{
		timer = 0;
	}
		
	void Update()
	{
		timer = Time.time;

		if (timer >= 30f) 
		{
			timer = 0;
			Initiate.Fade ("DayPrep", Color.black, 2);
		}
	}
}
