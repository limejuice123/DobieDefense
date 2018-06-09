using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BackToMenu : MonoBehaviour 
{
	public Button BackToMenuButton;

	void Start () 
	{
		BackToMenuButton = GameObject.Find ("BackToMenu").GetComponent<Button> ();
		BackToMenuButton.onClick.AddListener (TaskOnClick);
	}

	void TaskOnClick () 
	{
		Initiate.Fade ("MainMenu", Color.black, 2);
	}
}
