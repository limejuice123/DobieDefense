using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVariables : MonoBehaviour 
{
	public int Treats;
	public int Health;

	void Start ()
	{
		DontDestroyOnLoad (this);
	}
}
