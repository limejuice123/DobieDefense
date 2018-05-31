using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FinishAndPlay : MonoBehaviour 
{
	public Button FinishButton;

	void Start () 
	{
		FinishButton = GameObject.Find ("FinishButton").GetComponent<Button> ();
		FinishButton.onClick.AddListener (TaskOnClick);
	}

	void TaskOnClick () 
	{
		Initiate.Fade ("Game", Color.black, 2);
	}
}
