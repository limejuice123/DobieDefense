using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PressPlay : MonoBehaviour 
{
	public Button PlayButton;

	void Start () 
	{
		PlayButton = GameObject.Find ("PlayButton").GetComponent<Button> ();
		PlayButton.onClick.AddListener (TaskOnClick);
	}

	void TaskOnClick () 
	{
		Initiate.Fade ("Instructions", Color.black, 2);
	}
}
