﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovementAndWeapons : MonoBehaviour 
{
	[Range(0, 100)]
	public float MovementSpeed;
	public GlobalVariables Global;
	public Transform Sasha;
	public Transform CentrePoint;
	public Transform AboveButtons;
	public Transform LeftBoundary;
	public Transform RightBoundary;
	public Image FartImage;
	public Image VomitImage;
	public Text HealthText;
	public Text TreatText;

	void Start () 
	{
		Global = GameObject.Find ("GlobalVariables").GetComponent<GlobalVariables> ();
		Sasha = GameObject.Find ("Sasha").GetComponent<Transform> ();
		CentrePoint = GameObject.Find ("CentrePoint").GetComponent<Transform> ();
		AboveButtons = GameObject.Find ("AboveButtons").GetComponent<Transform> ();
		LeftBoundary = GameObject.Find ("LeftBoundary").GetComponent<Transform> ();
		RightBoundary = GameObject.Find ("RightBoundary").GetComponent<Transform> ();
		FartImage = GameObject.Find ("FartImage").GetComponent<Image> ();
		VomitImage = GameObject.Find ("VomitImage").GetComponent<Image> ();
		HealthText = GameObject.Find ("HealthAmount").GetComponent<Text> ();
		TreatText = GameObject.Find ("TreatsAmount").GetComponent<Text> ();

		if (Global.FartPurchased == false) 
		{
			FartImage.enabled = false;
		} 
		else 
		{
			FartImage.enabled = true;
		}

		if (Global.VomitPurchased == false) 
		{
			VomitImage.enabled = false;
		} 
		else 
		{
			VomitImage.enabled = true;
		}
	}

	void Update ()
	{
		if (Input.touchCount == 1) 
		{
			var pos = Camera.main.ScreenToWorldPoint (Input.GetTouch (0).position);

			if (pos.x > CentrePoint.position.x && pos.y > AboveButtons.position.y)
				Sasha.Translate (0, -MovementSpeed * Time.deltaTime, 0);

			if (pos.x < CentrePoint.position.x && pos.y > AboveButtons.position.y)
				Sasha.Translate (0, MovementSpeed * Time.deltaTime, 0);

			if (pos.y < AboveButtons.position.y) 
			{
				
			}
		}

		if (Input.GetKey("a"))
			Sasha.Translate (0, MovementSpeed * Time.deltaTime, 0);

		if (Input.GetKey ("d"))
			Sasha.Translate (0, -MovementSpeed * Time.deltaTime, 0);

		if (Input.GetKey ("space")) 
		{
			if (Global.LaserEyesPurchased == false) 
			{
				
			}
		}

		if (Sasha.position.x < LeftBoundary.position.x)
			Sasha.position = new Vector2(-3.34f, -2.49f);

		if (Sasha.position.x > RightBoundary.position.x)
			Sasha.position = new Vector2(3.34f, -2.49f);

		HealthText.text = "= " + Global.Health.ToString ();
		TreatText.text = "= " + Global.Treats.ToString ();
	}
}
