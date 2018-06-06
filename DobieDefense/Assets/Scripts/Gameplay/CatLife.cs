﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatLife : MonoBehaviour 
{
	public Transform Barricade;
	public int CatHealth;
	public GlobalVariables Global;

	void Start () 
	{
		Global = GameObject.Find ("GlobalVariables").GetComponent<GlobalVariables> ();
		Barricade = GameObject.Find ("barricade").GetComponent<Transform> ();
		CatHealth = 5;
	}

	void Update () 
	{
		if (this.transform.position.y <= Barricade.position.y) 
		{
			Global.Health = Global.Health - 5;
			Destroy (this.gameObject);
		}
	}
}
