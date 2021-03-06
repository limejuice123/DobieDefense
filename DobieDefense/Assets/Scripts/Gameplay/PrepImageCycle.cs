﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrepImageCycle : MonoBehaviour 
{
	public Image ThingToBuy;
	public Sprite[] ArrayOfSprites;
	public Button Next;
	public Button Previous;
	public int CycleNumber;

	public AudioSource source;

	void Start ()
	{
		Next = GameObject.Find ("Next").GetComponent<Button> ();
		Previous = GameObject.Find ("Previous").GetComponent<Button> ();
		ThingToBuy = GameObject.Find ("ThingToBuy").GetComponent<Image> ();
		source = gameObject.GetComponent<AudioSource> ();
		Next.onClick.AddListener (NextItem);
		Previous.onClick.AddListener (PreviousItem);
	}

	void Update () 
	{
		ThingToBuy.sprite = ArrayOfSprites [CycleNumber];
	}

	void NextItem ()
	{
		source.Play ();
		if (CycleNumber < ArrayOfSprites.Length - 1)
			CycleNumber++;
		else
			CycleNumber = 0;
	}

	void PreviousItem ()
	{
		source.Play ();
		if (CycleNumber > 0)
			CycleNumber--;
		else
			CycleNumber = 3;
	}
}
