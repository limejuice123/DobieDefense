using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NextPage : MonoBehaviour 
{
	public Button NextButton;
	public Button BackButton;
	public Image InstructionImage;
	public Sprite[] Images;
	public Text InstructionText;
	public int PageCount;

	public AudioSource source;

	void Start () 
	{
		NextButton = GameObject.Find ("NextPage").GetComponent<Button> ();
		BackButton = GameObject.Find ("BackPage").GetComponent<Button> ();
		InstructionImage = GameObject.Find ("InstructionImage").GetComponent<Image> ();
		InstructionText = GameObject.Find ("InstructionText").GetComponent<Text> ();
		source = Camera.main.GetComponent<AudioSource> ();
		NextButton.onClick.AddListener (GoToNextPage);
		BackButton.onClick.AddListener (GoBackAPage);
	}

	void Update ()
	{
		switch (PageCount) 
		{
		case 0:
			InstructionImage.sprite = Images [PageCount];
			InstructionText.text = "Help Sasha defend her home from the evil cats whom are sure to want to hurt Tiff somehow.";
			break;
		case 1:
			InstructionImage.sprite = Images [PageCount];
			InstructionText.text = "Move left and right by tapping and holding either side of the screen.";
			break;
		case 2:
			InstructionImage.sprite = Images [PageCount];
			InstructionText.text = "Bark at the cats by tapping and holding the button at the bottom of the screen.";
			break;
		case 3:
			InstructionImage.sprite = Images [PageCount];
			InstructionText.text = "If a cat hits the barricade, you will lose health. No health means game over!";
			break;
		case 4:
			InstructionImage.sprite = Images [PageCount];
			InstructionText.text = "Defeating cats gives Sasha treats which she can use to expand her cababilities in the shop before the next day.";
			break;
		}
	}

	void GoToNextPage () 
	{
		source.Play ();
		if (PageCount < 4)
			PageCount++;
		else
			Initiate.Fade ("DayPrep", Color.black, 2);
	}

	void GoBackAPage ()
	{
		source.Play ();
		if (PageCount > 0)
			PageCount--;
	}
}
