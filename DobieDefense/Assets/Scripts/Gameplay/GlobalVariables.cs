using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVariables : MonoBehaviour 
{
	public int Treats;
	public int Health;
	public bool LaserEyesPurchased;
	public bool VomitPurchased;
	public bool FartPurchased;

	void Start ()
	{
		DontDestroyOnLoad (this);
		Health = 100;
		Treats = 0;
		LaserEyesPurchased = false;
		VomitPurchased = false;
		FartPurchased = false;
	}
}
