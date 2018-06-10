using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fart : MonoBehaviour 
{
	public GlobalVariables Global;
	public Transform AboveButtons;
	public Transform BarkBoundaryRight;
	public Image FartImage;

	void Start ()
	{
		Global = GameObject.Find ("GlobalVariables").GetComponent<GlobalVariables> ();
		AboveButtons = GameObject.Find ("AboveButtons").GetComponent<Transform> ();
		BarkBoundaryRight = GameObject.Find ("BarkBoundaryRight").GetComponent<Transform> ();
		FartImage = GameObject.Find ("FartImage").GetComponent<Image> ();
	}

	void Update () 
	{
		if (Input.touchCount == 1) 
		{
			var pos = Camera.main.ScreenToWorldPoint (Input.GetTouch (0).position);

			if (Global.FartPurchased == true && pos.x > BarkBoundaryRight.position.x && pos.y < AboveButtons.position.y) 
			{
				var Cats = GameObject.FindGameObjectsWithTag ("Cat");

				foreach (GameObject Item in Cats) 
				{
					Destroy (Item);
				}

				Global.FartPurchased = false;
				FartImage.enabled = false;
			}
		}

		if (Input.GetKeyDown ("q"))
		{
			if (Global.FartPurchased == true) 
			{
				var Cats = GameObject.FindGameObjectsWithTag ("Cat");

				foreach (GameObject Item in Cats) 
				{
					Destroy (Item);
				}

				Global.FartPurchased = false;
			}	
		}
	}
}
