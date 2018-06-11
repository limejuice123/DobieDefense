using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FinishAndPlay : MonoBehaviour 
{
	public Button FinishButton;
	public AudioSource source;

	void Start () 
	{
		FinishButton = GameObject.Find ("FinishButton").GetComponent<Button> ();
		source = GameObject.Find ("ThingToBuy").GetComponent<AudioSource> ();
		FinishButton.onClick.AddListener (TaskOnClick);
	}

	void TaskOnClick () 
	{
		source.Play ();
		Initiate.Fade ("Game", Color.black, 2);
	}
}
