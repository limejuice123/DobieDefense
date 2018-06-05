using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalVariables : MonoBehaviour 
{
	public int Treats;
	public int Health;

	void Start ()
	{
		DontDestroyOnLoad (this);
		Health = 100;
		Treats = 0;
	}

	void OnEnable ()
	{
		SceneManager.sceneLoaded += OnSceneLoaded;
	}

	void OnSceneLoaded (Scene scene, LoadSceneMode mode)
	{
		Debug.Log ("OnSceneLoaded: " + scene.name);
	}

	void OnDisable()
	{
		SceneManager.sceneLoaded -= OnSceneLoaded;
	}
}
