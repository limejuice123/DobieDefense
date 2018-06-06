using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVariables : MonoBehaviour 
{
	public int Treats;
	public int Health;
	public int CurrentLevel;
	public bool LaserEyesPurchased;
	public bool VomitPurchased;
	public bool FartPurchased;

	void Start ()
	{
		DontDestroyOnLoad (this);
		Health = 100;
		Treats = 0;
		CurrentLevel = 0;
		LaserEyesPurchased = false;
		VomitPurchased = false;
		FartPurchased = false;
	}
}
