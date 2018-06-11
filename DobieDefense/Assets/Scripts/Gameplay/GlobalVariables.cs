using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalVariables : MonoBehaviour 
{
	private static GlobalVariables InstanceRef;

	public int Treats;
	public int Health;
	public int CurrentLevel;
	public bool LaserEyesPurchased;
	public bool FartPurchased;
	public bool isGameOver;

	void Awake()
	{
		if (InstanceRef == null) 
		{
			InstanceRef = this;
			DontDestroyOnLoad (gameObject);
		}
		else
			DestroyImmediate (gameObject);
	}

	void Start ()
	{
		Health = 100;
		Treats = 0;
		CurrentLevel = 0;
		LaserEyesPurchased = false;
		FartPurchased = false;
		isGameOver = false;
	}

	void OnEnable()
	{
		SceneManager.sceneLoaded += OnSceneLoaded;
	}

	void OnSceneLoaded(Scene scene, LoadSceneMode mode)
	{
		if (scene.name == "DayPrep")
			CurrentLevel++;
	}

	void OnDisable()
	{
		SceneManager.sceneLoaded -= OnSceneLoaded;
	}

	void Update()
	{
		if (Health <= 0 && isGameOver == false) 
		{
			isGameOver = true;
			Initiate.Fade ("GameOver", Color.black, 2f);
		}
	}
}
