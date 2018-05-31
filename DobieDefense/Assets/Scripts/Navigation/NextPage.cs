using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NextPage : MonoBehaviour 
{
	public Button NextButton;
	public Button BackButton;
	public Text InstructionText;
	public int PageCount;

	void Start () 
	{
		NextButton = GameObject.Find ("NextPage").GetComponent<Button> ();
		BackButton = GameObject.Find ("BackPage").GetComponent<Button> ();
		InstructionText = GameObject.Find ("InstructionText").GetComponent<Text> ();
		NextButton.onClick.AddListener (GoToNextPage);
		BackButton.onClick.AddListener (GoBackAPage);
	}

	void Update ()
	{
		switch (PageCount) 
		{
		case 0:
			InstructionText.text = "1";
			break;
		case 1:
			InstructionText.text = "2";
			break;
		case 2:
			InstructionText.text = "3";
			break;
		case 3:
			InstructionText.text = "4";
			break;
		case 4:
			InstructionText.text = "5";
			break;
		}
	}

	void GoToNextPage () 
	{
		if (PageCount < 4)
			PageCount++;
		else
			Initiate.Fade ("DayPrep", Color.black, 2);
	}

	void GoBackAPage ()
	{
		if (PageCount > 0)
			PageCount--;
	}
}
