using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PressPlay : MonoBehaviour 
{
	public Button PlayButton;
	public AudioSource source;

	void Start () 
	{
		PlayButton = GameObject.Find ("PlayButton").GetComponent<Button> ();
		source = gameObject.GetComponent<AudioSource> ();
		PlayButton.onClick.AddListener (TaskOnClick);
	}

	void TaskOnClick () 
	{
		source.Play ();
		Initiate.Fade ("Instructions", Color.black, 2);
	}
}
