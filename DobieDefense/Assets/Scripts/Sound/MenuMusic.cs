using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuMusic : MonoBehaviour 
{
	public GameObject SoundFile;

	void Start () 
	{
		SoundFile = GameObject.Find ("SoundFile");
		DontDestroyOnLoad (SoundFile);
		DontDestroyOnLoad (this.gameObject);
	}

	void OnEnable()
	{
		SceneManager.sceneLoaded += OnSceneLoaded;
	}

	void OnSceneLoaded(Scene scene, LoadSceneMode mode)
	{
		if (scene.name == "Game")
			SoundFile.SetActive (false);
		else
			SoundFile.SetActive (true);
	}

	void OnDisable()
	{
		SceneManager.sceneLoaded -= OnSceneLoaded;
	}
}
