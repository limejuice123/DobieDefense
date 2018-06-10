using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LaserScript : MonoBehaviour 
{
	public GameObject Laser;
	public Transform AboveButtons;
	public Transform BarkBoundaryLeft;
	public Transform BarkBoundaryRight;
	public Image LaserImage;
	public GlobalVariables Global;

	void Start () 
	{
		Global = GameObject.Find ("GlobalVariables").GetComponent<GlobalVariables> ();
		LaserImage = GameObject.Find ("LaserImage").GetComponent<Image> ();
		AboveButtons = GameObject.Find ("AboveButtons").GetComponent<Transform> ();
		BarkBoundaryLeft = GameObject.Find ("BarkBoundaryLeft").GetComponent<Transform> ();
		BarkBoundaryRight = GameObject.Find ("BarkBoundaryRight").GetComponent<Transform> ();
		Laser = GameObject.Find ("Laser");

		Laser.SetActive (false);

		if (Global.LaserEyesPurchased == false) 
		{
			LaserImage.enabled = false;
		} 
		else 
		{
			LaserImage.enabled = true;
		}
	}

	void Update () 
	{
		if (Global.LaserEyesPurchased == true && Input.touchCount == 1) 
		{
			var pos = Camera.main.ScreenToWorldPoint (Input.GetTouch (0).position);

			if (pos.x > BarkBoundaryLeft.position.x && pos.x < BarkBoundaryRight.position.x && pos.y < AboveButtons.position.y) 
			{
				Laser.SetActive (true);
			}
		}

		if (Input.touchCount == 0)
			Laser.SetActive (false);
	}
}
