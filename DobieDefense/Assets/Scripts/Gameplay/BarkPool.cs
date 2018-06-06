﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarkPool : MonoBehaviour 
{
	public GlobalVariables Global;

	public GameObject Bark;
	[Range(0, 10)]
	public float BarkSpeed;

	public Transform AboveButtons;

	public int PooledBarks;
	List<GameObject> ListOfBarks;

	void Start () 
	{
		Global = GameObject.Find ("GlobalVariables").GetComponent<GlobalVariables> ();
		ListOfBarks = new List<GameObject> ();
		for (int i = 0; i < PooledBarks; i++) 
		{
			GameObject obj = (GameObject)Instantiate (Bark);
			obj.SetActive (false);
			ListOfBarks.Add (obj);
		}
	}

	void Update ()
	{
		if (Input.touchCount == 1 && Global.LaserEyesPurchased == false) 
		{
			var pos = Camera.main.ScreenToWorldPoint (Input.GetTouch (0).position);

			if (pos.y < AboveButtons.position.y) 
			{
				for (int i = 0; i < ListOfBarks.Count; i++) 
				{
					if (!ListOfBarks [i].activeInHierarchy) 
					{
						ListOfBarks [i].transform.position = transform.position;
						ListOfBarks [i].transform.rotation = transform.rotation;
						ListOfBarks [i].SetActive (true);
						break;
					}
				}
			}
		}

		if (Input.GetKey ("space") && Global.LaserEyesPurchased == false) 
		{
			for (int i = 0; i < ListOfBarks.Count; i++) 
			{
				if (!ListOfBarks [i].activeInHierarchy) 
				{
					ListOfBarks [i].transform.position = transform.position;
					ListOfBarks [i].transform.rotation = transform.rotation;
					ListOfBarks [i].SetActive (true);
					break;
				}
			}
		}
	}
}
