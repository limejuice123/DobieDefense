using System.Collections;
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
		}

		if (Sasha.position.x < LeftBoundary.position.x)
			Sasha.position = new Vector2(-3.34f, -2.49f);

		if (Sasha.position.x > RightBoundary.position.x)
			Sasha.position = new Vector2(3.34f, -2.49f);
	}
}
